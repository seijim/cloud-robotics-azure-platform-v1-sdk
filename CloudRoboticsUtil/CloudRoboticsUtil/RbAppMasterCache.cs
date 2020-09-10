using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudRoboticsUtil
{
    [Serializable]
    public class RbAppMasterCache
    {
        public string AppId { set; get; } 
        public string StorageAccount { set; get; }
        public string StorageKey { set; get; }
        public string AppInfo { set; get; }
        public string AppInfoDevice { set; get; }
        public string Status { set; get; }
        public string Description { set; get; }
        public DateTime Registered_DateTime { set; get; }
        public DateTime CacheExpiredDatetime { set; get; }
    }
}