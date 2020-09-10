using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudRoboticsUtil
{
    public class RbAppDllCacheInfo
    {
        public string FileName { set; get; }
        public string CachedFileName { set; get; }
        public string CacheDir { set; get; }
        public string AppId { set; get; }
        public string AppProcessingId { set; get; }
        public DateTime Registered_DateTime { set; get; }
        public string GenerateCachedFileName()
        {
            int i = FileName.ToLower().IndexOf(".dll");
            string subFilename = FileName.Substring(0, i);
            this.CachedFileName = subFilename + this.Registered_DateTime.ToString("_yyyyMMddHHmmss") + ".dll";

            return this.CachedFileName;
        }
    }
}
