# -*- coding: utf-8 -*-
import urllib, urllib2
import base64
import hmac,hashlib
import datetime
import pytz
import os.path
import cStringIO

# Storage Account info
blob_account = "<Your_Storage_Account_Name>"
blob_accesskey = "<Your_Storage_Access_Key>"
blob_container = "<Your_Container_Name>"

# Local file info
file_path = "<File_Path (Example c:/temp/apep1.jpg)>"
file_name = os.path.basename(file_path)
html_body = open(file_path, "rb").read()

content_length = str(len(html_body))
content_type = "application/octet-stream" #default content type

# Blob Uri
blob_path = "/" + blob_account + "/" + blob_container + "/" + file_name
blob_url = "https://" + blob_account +".blob.core.windows.net/" + blob_container + "/" + file_name

print blob_url

# Create Signature String (https://msdn.microsoft.com/en-us/library/azure/dd179428.aspx)
verb = "PUT"
html_date = datetime.datetime.now(pytz.utc).strftime("%a, %d %b %Y %H:%M:%S GMT")
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

print stringToSign

signature = base64.encodestring(hmac.new(base64.decodestring(blob_accesskey),stringToSign,hashlib.sha256).digest())
signature = signature.rstrip("\n")
authorization = "SharedKey " + blob_account + ":" + signature
print authorization

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

