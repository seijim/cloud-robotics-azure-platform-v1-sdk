using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RbAppConversationApi
{
    public class IntentState
    {
        public string processState { set; get; }
        public string query { set; get; }
        public JObject topScoringIntent { set; get; }
        public JArray actionList { set; get; }
    }
}
