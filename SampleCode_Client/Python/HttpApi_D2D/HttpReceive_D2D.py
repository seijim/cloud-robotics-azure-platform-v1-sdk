# -*- coding: utf-8 -*-
import time, datetime
import urllib, urllib2
import hmac, hashlib
import base64
import json

# IoT Hub Info
p_hostname = "<iotHubName>.azure-devices.net"
p_deviceId = "<pep2_deviceId>"
p_sharedAccessKey = "<pep2_deviceKey>"

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
# Message Receive
#------------------------------------------------------------------------------
# HTTP Header(receive)
p_headersR = {
    "Authorization": p_token,
    "iothub-to": p_restAPIs['receive'],
    "User-Agent": "azure-iot-device/1.0.0"
}
# REST APIのBase URL
p_urlR = 'https://{hostname}{api}?api-version={api_version}'.format(hostname=p_hostname,
                        api=p_restAPIs['receive'], deviceId=p_deviceId, api_version=p_api_version)

headers = None
body = None
resCode = None
print('** Receive message loop started **')
while True:
    time.sleep(0.5)
    try:
        request = urllib2.Request(p_urlR, None, p_headersR)
        response = urllib2.urlopen(request)
        headers = response.info()
        body = response.read()
        resCode = response.code
        if resCode == 200:
            messageId = headers['ETag'].replace('\"','')
            print str(body)
            break
    except urllib2.HTTPError as he:
        print "\nFailed: " + str(he) + ", Response Code:" + str(he.code)
        break
    except Exception as e:
        print "\nFailed: " + str(e)
        break
    else:
        if resCode == 204: # No Content
            continue


#------------------------------------------------------------------------------
# Complete after Received (Delete Message)
#------------------------------------------------------------------------------
if resCode == 200 and headers['ETag'] is not None:
    p_headersCompl = {
        "Authorization": p_token,
        "iothub-to": p_restAPIs['complete'],
        "User-Agent": "azure-iot-device/1.0.0"
    }
    # REST APIのBase URL
    p_urlCompl = 'https://{hostname}{api}?api-version={api_version}'.format(hostname=p_hostname,
                            api=p_restAPIs['complete'], deviceId=p_deviceId, api_version=p_api_version)

    if messageId is not None:
        p_urlCompl = p_urlCompl.replace('messageId', messageId)

    request = urllib2.Request(p_urlCompl, None, p_headersCompl)
    request.get_method = lambda: 'DELETE'
    urllib2.urlopen(request)

