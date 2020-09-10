using Newtonsoft.Json.Linq;

namespace RbAppConversationApi
{
    public class AppResult
    {
        public ApiResult apiResult { set; get; }
        public string conversationStateString { set; get; }
    }
}
