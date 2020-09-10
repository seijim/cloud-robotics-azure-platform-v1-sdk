# -*- coding: utf-8 -*-
#
# 顔認識API用メッセージ
#
# @author: Hiroki Wakabayashi <hiroki.wakabayashi@jbs.com>
# @version: 0.0.1

import cloudrobotics.message as message

PROCESSING_ID_FACERECOGNITION = 'RbAppFaceApi'

# 初期化メッセージ
#
class InitMessage(message.CRFXMessage):

    def __init__(self):
        super(InitMessage, self).__init__()

        self.header['RoutingType'] = message.ROUTING_TYPE_CALL
        self.header['AppProcessingId'] = PROCESSING_ID_FACERECOGNITION
        self.header['MessageId'] = 'init'

        self.body = {}

# 顔登録メッセージ
#
class RegisterMessage(message.CRFXMessage):

    def __init__(self, visitor, groupid, visitor_name, visitor_name_kana, file_name, locationid='all', delete_file='true'):
        super(RegisterMessage, self).__init__()

        self.header['RoutingType'] = message.ROUTING_TYPE_CALL
        self.header['AppProcessingId'] = PROCESSING_ID_FACERECOGNITION
        self.header['MessageId'] = 'registerFace'

        self.body = {
            'visitor': visitor,
            'groupId': groupid,
            'locationId': locationid,
            'visitor_name': visitor_name,
            'visitor_name_kana': visitor_name_kana,
            'blobFileName': file_name,
            'deleteFile': delete_file
        }

# 顔属性取得・顔特定メッセージ
#
class RecognizeMessage(message.CRFXMessage):

    def __init__(self, visitor, groupid, file_name, locationid='all', delete_file='true'):
        super(RecognizeMessage, self).__init__()

        self.header['RoutingType'] = message.ROUTING_TYPE_CALL
        self.header['AppProcessingId'] = PROCESSING_ID_FACERECOGNITION
        self.header['MessageId'] = 'getFaceInfo'

        self.body = {
            'visitor': visitor,
            'groupId': groupid,
            'locationId': locationid,
            'blobFileName': file_name,
            'deleteFile': delete_file
        }

