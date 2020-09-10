using System;
using System.Collections.Generic;

namespace RbAppTranslatorApi
{
    public class ResBody
    {
        public string success { set; get; }
        public string visitor { set; get; }
        public string visitor_id { set; get; }
        public string translated_text { set; get; }
    }

    public class ResBodyWhenError
    {
        public string success { set; get; }
        public string error_message { set; get; }
    }
}