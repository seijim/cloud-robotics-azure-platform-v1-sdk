# -*- coding: utf-8 -*-
#
# ストレージ
# 
# @author: Hiroki Wakabayashi <hiroki.wakabayashi@jbs.com>
# @version: 0.0.1

import urllib, urllib2
import base64
import hmac,hashlib
import datetime
#import pytz
import os.path

def upload_to_storage(blob_account, blob_accesskey, blob_container, file_path):
    file_name = os.path.basename(file_path)
    html_body = open(file_path, "rb").read()

    content_length = str(len(html_body))
    content_type = "application/octet-stream"

    # Blob Uri
    blob_path = "/" + blob_account + "/" + blob_container + "/" + file_name
    blob_url = "https://" + blob_account +".blob.core.windows.net/" + blob_container + "/" + file_name

    # Create Signature String (https://msdn.microsoft.com/en-us/library/azure/dd179428.aspx)
    verb = "PUT"
    html_date = datetime.datetime.now().strftime("%a, %d %b %Y %H:%M:%S GMT")

    ms_version = "2015-07-08"
    ms_blob_type = "BlockBlob"

    stringToSign = verb + "\n" #HTTP Verb
    stringToSign += "\n" #Content-Encoding
    stringToSign += "\n" #Content-Language
    stringToSign += content_length + "\n" #Content-Length
    stringToSign += "\n" #Content-MD5
    stringToSign += content_type + "\n" #Content-Type
    stringToSign += "\n" #Date
    stringToSign += "\n" #If-Modified-Since
    stringToSign += "\n" #If-Match
    stringToSign += "\n" #If-None-Match
    stringToSign += "\n" #If-Unmodified-Since
    stringToSign += "\n" #Range
    stringToSign += "x-ms-blob-type:" + ms_blob_type + "\n"
    stringToSign += "x-ms-date:" + html_date + "\n"
    stringToSign += "x-ms-version:" + ms_version + "\n"
    stringToSign += blob_path

    signature = base64.encodestring(hmac.new(base64.decodestring(blob_accesskey),stringToSign,hashlib.sha256).digest())
    signature = signature.rstrip("\n")
    authorization = "SharedKey " + blob_account + ":" + signature

    # Create HTTP request
    html_headers = {
        "Content-Type": content_type,
        "Content-Length": content_length,
        "x-ms-blob-type": ms_blob_type,
        "x-ms-date": html_date,
        "x-ms-version": ms_version,
        "Authorization": authorization
    }

    # Put binary data to Blob
    opener = urllib2.build_opener(
        urllib2.HTTPSHandler(debuglevel=0)
    )

    urllib2.install_opener(opener)
    request = urllib2.Request(blob_url, html_body, html_headers)
    request.get_method = lambda: verb
    urllib2.urlopen(request)