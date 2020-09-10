using System;
using System.Collections.Generic;

namespace RbAppConversationApi
{
    public class ResBody
    {
        public string success { set; get; }
        public string visitor { set; get; }
        public string visitor_id { set; get; }
        public string type { set; get; }
    }

    public class ResBodyWhenError
    {
        public string success { set; get; }
        public string error_message { set; get; }
    }

    public class ResBodyTalk
    {
        public string success { set; get; }
        public string visitor { set; get; }
        public string visitor_id { set; get; }
        public string type { set; get; }
        public List<TalkMessage> talkByAi { set; get; }
    }

    public class TalkMessage
    {
        public string SayText { set; get; }
    }
}