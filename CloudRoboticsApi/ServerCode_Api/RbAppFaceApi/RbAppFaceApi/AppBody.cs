using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RbAppFaceApi
{
    public class AppBodyInit
    {
        public string storageAccount { set; get; }
        public string storageKey { set; get; }
        public string storageContainer { set; get; }
        public AppBodyInit()
        {
            this.storageAccount = string.Empty;
            this.storageKey = string.Empty;
            this.storageContainer = string.Empty;

        }
    }

    public class AppBodyFaceInfo
    {
        public string success { set; get; }
        public string visitor { set; get; }
        public string groupId { set; get; }
        public string locationId { set; get; }
        public string gender { set; get; }
        public string age { set; get; }
        public string smile { set; get; }
        public string glasses { set; get; }
        public string facialHair { set; get; }
        public string visitor_id { set; get; }
        public string visitor_name { set; get; }
        public string visitor_name_kana { set; get; }
        public string visitor_faceId { set; get; }
        public string face_confidence { set; get; }
        public string visit_count { set; get; }
        public AppBodyFaceInfo()
        {
            this.visitor = string.Empty;
            this.groupId = string.Empty;
            this.locationId = string.Empty;
            this.gender = string.Empty;
            this.age = string.Empty;
            this.smile = string.Empty;
            this.glasses = string.Empty;
            this.facialHair = string.Empty;
            this.visitor_id = string.Empty;
            this.visitor_name = string.Empty;
            this.visitor_name_kana = string.Empty;
            this.visitor_faceId = string.Empty;
            this.face_confidence = string.Empty;
            this.visit_count = string.Empty;
        }
    }

    public class AppBodyRegResult
    {
        public string success { set; get; }
        public string visitor { set; get; }
        public string groupId { set; get; }
        public string locationId { set; get; }
        public string visitor_id { set; get; }
        public string visitor_name { set; get; }
        public string visitor_name_kana { set; get; }
        public AppBodyRegResult()
        {
            this.visitor = string.Empty;
            this.visitor_id = string.Empty;
            this.groupId = string.Empty;
            this.locationId = string.Empty;
            this.visitor_name = string.Empty;
            this.visitor_name_kana = string.Empty;
            this.success = string.Empty;
        }
    }

    public class AppBodyWhenError
    {
        public string success { set; get; }
        public string error_message { set; get; }
        public AppBodyWhenError()
        {
            this.success = string.Empty;
            this.error_message = string.Empty;
        }

    }
}