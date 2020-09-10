# -*- coding: utf-8 -*-
#
# Cloud Robotics FX メッセージ
#
# @author: Hiroki Wakabayashi <hiroki.wakabayashi@jbs.com>
# @version: 0.0.1

import json
import datetime

ROUTING_TYPE_D2D = 'D2D';
ROUTING_TYPE_LOG = 'LOG';
ROUTING_TYPE_CALL = 'CALL';

API_APP_ID = 'SbrApiServices';

class CRFXMessage(object):
    def __init__(self):
        self.header = {
            'RoutingType': None
            ,'RoutingKeyword': 'Default'
            ,'AppId': API_APP_ID
            ,'AppProcessingId': None
            ,'MessageId': None
            ,'MessageSeqno': None
        }
        self.body = {}

    # シーケンス番号を設定する。
    def set_seq(self, seqno):
        self.header['MessageSeqno'] = seqno #str(seqno)

    # シーケンス番号を取得する。
    def get_seq(self):
        return self.header['MessageSeqno']

    # メッセージ本文を生成する。
    def payload(self, seqNo=None):
        now = datetime.datetime.now()
        self.header['SendDateTime'] = now.strftime('%Y-%m-%d %H:%M:%S.')+'%03d' % (now.microsecond // 1000)

        # Bodyにセットされてくる値に応じて処理を切り替える。
        if isinstance(self.body, str):
            body = self.body.decode('utf-8')
        elif isinstance(self.body, dict):
            body = json.loads(json.dumps(self.body))

        pyld = {
            'RbHeader':self.header
            ,'RbBody':body
        }

        return json.dumps(pyld, ensure_ascii=False, separators=(',', ':'))

    # JSON文字列を読み込む
    #
    def loads(self, jsontext):
        try:
            print jsontext
            data = json.loads(jsontext)

            self.header = {}
            self.body = {}

            for k, v in data[u'RbHeader'].iteritems():
                self.header[k.encode('utf-8')] = self.encode(v)

            for k, v in data[u'RbBody'].iteritems():
                self.body[k.encode('utf-8')] = self.encode(v)
        except Exception as e:
            print(e)
            self.header = None
            self.body = None

    # unicode型の場合にutf-8にエンコードする。
    #
    def encode(self, val):
        if val is None:
            return None
        elif isinstance(val, unicode):
            return val.encode('utf-8')
        elif isinstance(val, list):
            newVal = []
            for v in val:
                newVal.append(self.encode(v))

            return newVal
        elif isinstance(val, dict):
            newVal = {}
            for i, v in val.iteritems():
                newVal[i.encode('utf-8')] = self.encode(v)

            return newVal
        else:
            return val