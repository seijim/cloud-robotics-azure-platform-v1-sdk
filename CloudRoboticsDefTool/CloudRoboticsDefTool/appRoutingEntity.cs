using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudRoboticsDefTool
{
    public class AppRoutingEntity : IComparable<AppRoutingEntity>
    {
        public string AppId { set; get; }
        public string AppProcessingId { set; get; }
        public string BlobContainer { set; get; }
        public string FileName { set; get; }
        public string ClassName { set; get; }
        public string Status { set; get; }
        public string DevMode { set; get; }
        public string DevLocalDir { set; get; }
        public string Description { set; get; }
        public DateTime Registered_DateTime { set; get; }

        public int CompareTo(AppRoutingEntity other)
        {
            return string.Compare(this.AppId + this.AppProcessingId, other.AppId + other.AppProcessingId
                , StringComparison.OrdinalIgnoreCase);
        }

    }
}
