# -*- coding: utf-8 -*-
#
# Cloud Robotics FX 翻訳APIクライアント
#
# @author: Osamu Noguchi <noguchi@headwaters.co.jp>
# @version: 0.0.1

import logging
import json
import os

from cloudrobotics.client import CRFXClient
from cloudrobotics.message import CRFXMessage
import cloudrobotics.translator.message as message
import cloudrobotics.storage as storage

class CRFXTranslatorClient(CRFXClient):
    def __init__(self, hostname, deviceid, shared_accesskey):
        super(CRFXTranslatorClient, self).__init__(hostname, deviceid, shared_accesskey)

        # 親クラスのメッセージ受信処理を上書きする。
        self.mqtt_client.on_message = self.__on_message
        
        self.on_translated = None

        logging.basicConfig()
        self.logger = logging.getLogger(__name__)
        self.logger.setLevel(logging.DEBUG)
    
    # メッセージ受信時の処理 (override)
    #
    def __on_message(self, client, userdata, msg):
        received_message = CRFXMessage()
        received_message.loads(msg.payload)

        if self.on_message: self.on_message(received_message)

        try:
            if received_message.header is None or received_message.body is None:
                raise Exception('message header or body is None.')

            # 翻訳API関連のメッセージのみを処理する。
            if received_message.header['AppId'] == message.APP_ID and received_message.header['AppProcessingId'] == message.PROCESSING_ID:
                if self.on_translated:
                    self.on_translated(received_message.body['success'],
                                        received_message.get_seq(),
                                        (received_message.body['visitor'] if 'visitor' in received_message.body else None),
                                        received_message.body)

        except Exception as e:
            self.logger.error('Failed to parse received message data, because: %s', str(e))

    # 翻訳
    #
    def translate(self, visitor, visitor_id, text, tolang='en'):
        # メッセージ送信
        return self.send_message(message.TranslatorMessage(visitor, visitor_id, text, tolang))
