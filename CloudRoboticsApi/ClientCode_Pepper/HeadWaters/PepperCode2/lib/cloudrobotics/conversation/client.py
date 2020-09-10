# -*- coding: utf-8 -*-
#
# Cloud Robotics FX 会話理解APIクライアント
#
# @author: Osamu Noguchi <noguchi@headwaters.co.jp>
# @version: 0.0.1

import logging
import json
import os

from cloudrobotics.client import CRFXClient
from cloudrobotics.message import CRFXMessage
import cloudrobotics.conversation.message as message

class CRFXConversationClient(CRFXClient):
    def __init__(self, hostname, deviceid, shared_accesskey):
        super(CRFXConversationClient, self).__init__(hostname, deviceid, shared_accesskey)

        # 親クラスのメッセージ受信処理を上書きする。
        self.mqtt_client.on_message = self.__on_message
        
        self.on_talk_received = None
        self.on_launch_received = None
        self.type = 'init'

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

            # 会話理解API関連のメッセージのみを処理する。
            if received_message.header['AppId'] == message.APP_ID and received_message.header['AppProcessingId'] == message.PROCESSING_ID:
                if self.on_talk_received and (received_message.body['type'] == 'init' or len(received_message.body['type']) >= 4 and received_message.body['type'][0:4] == 'talk'):
                    if received_message.body['success'] == 'true': self.type = 'init' if received_message.body['type'] == '' else received_message.body['type']
                    self.on_talk_received(received_message.body['success'],
                                        received_message.get_seq(),
                                        (received_message.body['visitor'] if 'visitor' in received_message.body else None),
                                        received_message.body)

                elif received_message.body['type'] == 'finishTalk':
                    if not received_message.body['success']: received_message.body['success'] = 'true'
                    self.type = 'init'
                    self.on_talk_received(received_message.body['success'],
                                        received_message.get_seq(),
                                        (received_message.body['visitor'] if 'visitor' in received_message.body else None),
                                        received_message.body)

                elif self.on_launch_received and (len(received_message.body['type']) >= 6 and received_message.body['type'][0:6] == 'launch'):
                    self.on_launch_received(received_message.body['success'],
                                        received_message.get_seq(),
                                        (received_message.body['visitor'] if 'visitor' in received_message.body else None),
                                        received_message.body)

        except Exception as e:
            self.logger.error('Failed to parse received message data, because: %s', str(e))

    # 会話
    #
    def converse(self, visitor, visitor_id, talkByMe):
        # メッセージ送信
        return self.send_message(message.ConversationMessage(visitor, visitor_id, talkByMe, self.type))

if __name__ == "__main__":
    client = crfx.CRFXConversationClient('pephackiothub.azure-devices.net', 'pep050_1', 'hq6UiDIGTEfuONRS0DN7HLbl6w0RZOyfkbB0lwkChW8=')
