# -*- coding: utf-8 -*-
#
# Cloud Robotics FX 翻訳API用メッセージ
#
# @author: Osamu Noguchi <noguchi@headwaters.co.jp>
# @version: 0.0.1

import cloudrobotics.message as message
APP_ID = 'SbrApiServices'
PROCESSING_ID = 'RbAppTranslatorApi'

# 翻訳メッセージ
#
class TranslatorMessage(message.CRFXMessage):
    
    def __init__(self, visitor, visitor_id, text, tolang='en'):
        super(TranslatorMessage, self).__init__()

        self.header['RoutingType'] = message.ROUTING_TYPE_CALL
        self.header['AppProcessingId'] = PROCESSING_ID

        self.body = {
            'visitor': visitor,
            'visitor_id': visitor_id,
            'text': text,
            'tolang': tolang
        }
