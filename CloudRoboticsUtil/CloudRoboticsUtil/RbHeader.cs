using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudRoboticsUtil
{
    [Serializable]
    public class RbHeader
    {
        public string RoutingType { set; get; }
        public string RoutingKeyword { set; get; }
        public string AppId { set; get; }
        public string AppProcessingId { set; get; }
        public string MessageId { set; get; }
        public long MessageSeqno { set; get; }
        public DateTime SendDateTime { set; get; }
        public string SourceDeviceId { set; get; }
        public string SourceDeviceType { set; get; }
        public string SourceDevRescGroupId { set; get; }
        public string TargetType { set; get; }
        public string TargetDeviceGroupId { set; get; }
        public string TargetDeviceId { set; get; }
        public string ProcessingStack { set; get; }
    }
}
