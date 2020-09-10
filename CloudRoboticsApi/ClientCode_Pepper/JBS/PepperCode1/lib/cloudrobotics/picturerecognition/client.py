# -*- coding: utf-8 -*-
#
# Cloud Robotics FX 写真説明APIクライアント
#
# @author: Hiroki Wakabayashi <hiroki.wakabayashi@jbs.com>
# @version: 0.0.1

import logging
import json
import os

from cloudrobotics.client import CRFXClient
from cloudrobotics.message import CRFXMessage
import cloudrobotics.picturerecognition.message as message
import cloudrobotics.storage as storage

class CRFXPictureRecognitionClient(CRFXClient):
    def __init__(self, hostname, deviceid, shared_accesskey):
        super(CRFXPictureRecognitionClient, self).__init__(hostname, deviceid, shared_accesskey)

        # 親クラスのメッセージ受信処理を上書きする。
        self.mqtt_client.on_message = self.__on_message

        # Callback
        self.on_initialize = None
        self.on_analyze = None

        # Blob Storageの情報
        self.storage = {
            'account': None,
            'key':  None,
            'container': None
        }

        # 初期化済=Blob Storageの情報を取得済かどうか
        self.initialized = False

        logging.basicConfig()
        self.logger = logging.getLogger(__name__)
        self.logger.setLevel(logging.DEBUG)

    # ストレージアカウントの情報を取得するためのメッセージを送信する。
    #
    def init(self):
        self.send_message(message.InitMessage())
    
    # メッセージ受信時の処理 (override)
    #
    def __on_message(self, client, userdata, msg):
        received_message = CRFXMessage()
        received_message.loads(msg.payload)

        if self.on_message: self.on_message(received_message)

        try:
            if received_message.header is None or received_message.body is None:
                raise Exception('message header or body is None.')

            # 顔認識API関連のメッセージのみを処理する。
            if received_message.header['AppProcessingId'] == message.PROCESSING_ID_PICTURECOGNITION:
                # 初期化(ストレージ情報の取得)
                if received_message.header['MessageId'] == 'init':
                    self.storage['account'] = received_message.body['storageAccount']
                    self.storage['key'] = received_message.body['storageKey']
                    self.storage['container'] = received_message.body['storageContainer']
                    self.initialized = True

                    if self.on_initialize: self.on_initialize(self.storage)
                # 顔登録
                elif received_message.header['MessageId']  == 'analyze':
                    if self.on_analyze:
                        self.on_analyze(received_message.body['success'],
                                         received_message.get_seq(),
                                         (received_message.body['visitor'] if 'visitor' in received_message.body else None),
                                         received_message.body)

        except Exception as e:
            self.logger.error('Failed to parse received message data, because: %s', str(e))


    # 分析
    #
    def analyze(self, visitor, file_path, delete_file='true'):
        # Blob Storageの情報が取得できているかどうかをチェックする。
        if not self.initialized:
            self.logger.error('Failed to analyze this picture, because this client is not initialized.')
            return None
        
        # Blob Storageに写真をアップロードする。
        try:
            storage.upload_to_storage(self.storage['account'], self.storage['key'], self.storage['container'], file_path)
        except Exception as e:
            self.logger.error('Failed to analyze this picture, because could not upload the image file to the Azure Blob Storage Service.')
            return None

        # メッセージ送信
        return self.send_message(message.AnalyzeMessage(visitor, os.path.basename(file_path), delete_file))
