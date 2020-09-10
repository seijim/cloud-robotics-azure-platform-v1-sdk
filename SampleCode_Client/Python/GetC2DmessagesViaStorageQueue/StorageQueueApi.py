# -*- coding: utf-8 -*-
import urllib
import urllib2
import base64
import hmac,hashlib
import datetime
import pytz
import os.path
import cStringIO
from xml.etree.ElementTree import *

# Create Signature String (https://msdn.microsoft.com/en-us/library/azure/dd179428.aspx)
def create_html_headers(verb, queue_path):
    html_date = datetime.datetime.now(pytz.utc).strftime("%a, %d %b %Y %H:%M:%S GMT")
    ms_version = "2015-07-08"

    stringToSign = verb + "\n" #HTTP Verb
    stringToSign += "\n" #Content-Encoding
    stringToSign += "\n" #Content-Language
    stringToSign += "\n" #Content-Length
    stringToSign += "\n" #Content-MD5
    stringToSign += "\n" #Content-Type
    stringToSign += "\n" #Date
    stringToSign += "\n" #If-Modified-Since
    stringToSign += "\n" #If-Match
    stringToSign += "\n" #If-None-Match
    stringToSign += "\n" #If-Unmodified-Since
    stringToSign += "\n" #Range
    stringToSign += "x-ms-date:" + html_date + "\n"
    stringToSign += "x-ms-version:" + ms_version + "\n"
    stringToSign += queue_path
    # Create Signature
    signature = base64.encodestring(hmac.new(base64.decodestring(storage_key),stringToSign,hashlib.sha256).digest())
    signature = signature.rstrip("\n")
    # Create Authorization
    authorization = "SharedKey " + storage_account + ":" + signature
    # Create HTTP request
    html_headers = {
        "x-ms-date": html_date,
        "x-ms-version": ms_version,
        "Authorization": authorization
    }
    return html_headers

# Storage Account info
storage_account = "xxxxxxxxxxxx"
storage_key = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
queue_name = "<device_name>"

# Storage Queue Uri
queue_uri = "https://" + storage_account +".queue.core.windows.net/" + queue_name + "/messages"
queue_path = "/" + storage_account + "/" + queue_name + "/messages"

# HTTP Request
opener = urllib2.build_opener(
    urllib2.HTTPSHandler(debuglevel=0)
)
urllib2.install_opener(opener)

# Get message from Storage Queue
verb = "GET"
html_headers = create_html_headers(verb, queue_path)
request = urllib2.Request(queue_uri, headers=html_headers)
request.get_method = lambda: verb
f = urllib2.urlopen(request)
statusCode = f.getcode()
print("Status code : " + str(statusCode))
resXML = f.read()
print("")
print("XML : ")
print(resXML)

elem = fromstring(resXML)
elemMessageText = elem.find(".//MessageText")
if elemMessageText is not None:
    messageText = base64.decodestring(elemMessageText.text)
    print("")
    print("MessageText : ")
    print(messageText)
    # Delete message from Storage Queue
    verb = "DELETE"
    elemMessageId = elem.find(".//MessageId")
    elemPopReceipt = elem.find(".//PopReceipt")
    queue_uri += "/" + elemMessageId.text + "?popreceipt=" + elemPopReceipt.text
    queue_path += "/" + elemMessageId.text + "\npopreceipt:" + elemPopReceipt.text
    html_headers = create_html_headers(verb, queue_path)
    request = urllib2.Request(queue_uri, headers=html_headers)
    request.get_method = lambda: verb
    f = urllib2.urlopen(request)
    statusCode = f.getcode()
    print("")
    print("Status code : " + str(statusCode))


