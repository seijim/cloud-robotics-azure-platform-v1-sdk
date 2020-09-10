using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CloudRoboticsUtil;

namespace RbSampleApp
{
    public class SayHello : MarshalByRefObject, IAppRouterDll
    {
        public JArrayString ProcessMessage(RbAppMasterCache rbappmc, RbAppRouterCache rbapprc, RbHeader rbh, string rbBodyString)
        {
            JArray ja_messages = new JArray();
            AppBody appbody = new AppBody();
            appbody.Hello = "Hello World !!!!!!";

            RbMessage message = new RbMessage();
            message.RbHeader = rbh;
            message.RbBody = appbody;

            string json_message = JsonConvert.SerializeObject(message);
            JObject jo = (JObject)JsonConvert.DeserializeObject(json_message);
            ja_messages.Add(jo);
            JArrayString jaString = new JArrayString(ja_messages);

            return jaString;
        }
    }

}
