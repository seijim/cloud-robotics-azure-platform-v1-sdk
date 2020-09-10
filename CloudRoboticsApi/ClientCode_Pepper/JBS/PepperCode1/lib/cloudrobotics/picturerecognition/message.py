# -*- coding: utf-8 -*-
#
# 写真説明API用メッセージ
#
# @author: Hiroki Wakabayashi <hiroki.wakabayashi@jbs.com>
# @version: 0.0.1

import cloudrobotics.message as message

PROCESSING_ID_PICTURECOGNITION = 'RbAppVisionApi'

# 初期化メッセージ
#
class InitMessage(message.CRFXMessage):

    def __init__(self):
        super(InitMessage, self).__init__()

        self.header['RoutingType'] = message.ROUTING_TYPE_CALL
        self.header['AppProcessingId'] = PROCESSING_ID_PICTURECOGNITION
        self.header['MessageId'] = 'init'

        self.body = {}

# 分析メッセージ
#
class AnalyzeMessage(message.CRFXMessage):

    def __init__(self, visitor, file_name, delete_file='true'):
        super(AnalyzeMessage, self).__init__()

        self.header['RoutingType'] = message.ROUTING_TYPE_CALL
        self.header['AppProcessingId'] = PROCESSING_ID_PICTURECOGNITION
        self.header['MessageId'] = 'analyze'

        self.body = {
            'visitor': visitor,
            'blobFileName': file_name,
            'deleteFile': delete_file
        }

