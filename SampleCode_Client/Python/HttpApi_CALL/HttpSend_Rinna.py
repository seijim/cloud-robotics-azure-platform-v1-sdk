# -*- coding: utf-8 -*-
import time, datetime
import urllib, urllib2
import hmac, hashlib
import base64
import json

# IoT Hub Info
p_hostname = "<iotHubName>.azure-devices.net"
p_deviceId = "<pep1_deviceId>"
p_sharedAccessKey = "<pep1_deviceKey>"

# Application Info for Cloud Robotics FX
p_routingType = "CALL"
p_routingKeyword = ""
p_appId = "PepperShopApp"
p_appProcessingId = "RbAppRinnaApi"
p_messageId = ""
p_messageSeqno = 1

#------------------------------------------------------------------------------
# Create Token
#------------------------------------------------------------------------------
# Expiry time = 60sec
expireTerm=60
expiry = time.mktime(datetime.datetime.now().utctimetuple())+expireTerm
expiry = str(int(expiry))

uri = "{hostname}/devices/{deviceId}".format(hostname=p_hostname, deviceId=p_deviceId)
uri_enc = urllib.quote(uri, safe='')
signature = uri_enc + '\n' + expiry

# Decode sharedAccessKey because it is encoded with Base64.
k = bytes(base64.b64decode(p_sharedAccessKey))
v = bytes(signature)

# Use HMAC-SHA256 for signature
sig_enc = base64.b64encode(hmac.new(k, v, digestmod=hashlib.sha256).digest())
sig_enc = urllib.quote(sig_enc, safe='')
p_token = 'SharedAccessSignature sig=' + sig_enc + '&se=' + expiry + '&sr=' + uri_enc + '&skn='

# REST API Version
p_api_version = '2016-02-03'
# REST API Endpoint URI
p_restAPIs = {
    'send': '/devices/{deviceId}/messages/events'.format(deviceId=p_deviceId)
    ,'receive': '/devices/{deviceId}/messages/devicebound'.format(deviceId=p_deviceId)
    ,'complete': '/devices/{deviceId}/messages/devicebound/messageId'.format(deviceId=p_deviceId)
}

#------------------------------------------------------------------------------
# Message Send
#------------------------------------------------------------------------------
# REST API Base URL
p_url = 'https://{hostname}{api}?api-version={api_version}'.format(hostname=p_hostname,
                        api=p_restAPIs['send'], deviceId=p_deviceId, api_version=p_api_version)

# HTTP Header(send)
p_headers = {
    "Authorization": p_token,
    "iothub-to": p_restAPIs['send'],
    "User-Agent": "azure-iot-device/1.0.0"
}

# Send Message
opener = urllib2.build_opener(
    urllib2.HTTPSHandler(debuglevel=1)
)
now = datetime.datetime.now()
sdatetime = now.strftime("%Y-%m-%d %H:%M:%S.") + "%03d" % (now.microsecond // 1000)

payload = {
    "RbHeader":{
        "RoutingType": str(p_routingType),
        "RoutingKeyword": str(p_routingKeyword),
        "AppId": str(p_appId),
        "AppProcessingId": str(p_appProcessingId),
        "MessageId": str(p_messageId),
        "MessageSeqno": str(p_messageSeqno),
        "SendDateTime": str(sdatetime)
    },
    "RbBody":{
        "visitor": "u002",
        "visitor_id": "x01-0023",
        "talkByMe": "遅くねー"
    }
}
message = json.dumps(payload)

urllib2.install_opener(opener)
request = urllib2.Request(p_url, message, p_headers)
urllib2.urlopen(request)
