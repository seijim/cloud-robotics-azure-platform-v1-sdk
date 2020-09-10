using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CloudRoboticsUtil
{
    public interface IAppRouterDll
    {
        JArrayString ProcessMessage(RbAppMasterCache rbAppMasterCache, RbAppRouterCache rbAppRouterCache, 
            RbHeader rbHeader, string rbBodyString);

    }

    [Serializable]
    public class JArrayString
    {
        public string Value { set; get; }

        public JArrayString(JArray ja)
        {
            this.Value = JsonConvert.SerializeObject(ja);
        }

        public JArray ConvertToJArray()
        {
            return (JsonConvert.DeserializeObject<JArray>(this.Value));
        }
    }
}
