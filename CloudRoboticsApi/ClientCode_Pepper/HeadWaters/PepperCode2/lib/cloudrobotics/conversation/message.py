# -*- coding: utf-8 -*-
#
# Cloud Robotics FX 会話理解API用メッセージ
#
# @author: Osamu Noguchi <noguchi@headwaters.co.jp>
# @version: 0.0.1

import cloudrobotics.message as message
APP_ID = 'SbrApiServices'
PROCESSING_ID = 'RbAppConversationApi'

# 会話メッセージ
#
class ConversationMessage(message.CRFXMessage):
    
    def __init__(self, visitor, visitor_id, talkByMe, type):
        super(ConversationMessage, self).__init__()

        self.header['RoutingType'] = message.ROUTING_TYPE_CALL
        self.header['AppProcessingId'] = PROCESSING_ID
        self.header['MessageId'] = type

        self.body = {
            'visitor': visitor,
            'visitor_id': visitor_id,
            'talkByMe': talkByMe
        }
