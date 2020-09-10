using System;
using System.Collections.Generic;

namespace RbAppVisionApi
{
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

    public class AnalyzeBody
    {

        public string success { set; get; }
        public string visitor { set; get; }
        public string visitor_id { set; get; }
        public string Description { set; get; }
        public string Description_jp { set; get; }
        public string IsAdultContent { set; get; }
        public string IsRacyContent { set; get; }
        public Object Faces { set; get; }
        public Object Tags { set; get; }

        public AnalyzeBody()
        {
            this.success = string.Empty;
            this.visitor = string.Empty;
            this.visitor_id = string.Empty;
            this.Description = string.Empty;
            this.Description_jp = string.Empty;
            this.IsAdultContent = string.Empty;
            this.IsRacyContent = string.Empty;
            this.Faces = new Dictionary<string, object>();
            this.Tags = new Dictionary<string, object>();
        }
    }
}

