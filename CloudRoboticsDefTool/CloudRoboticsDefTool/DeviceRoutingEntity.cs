using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudRoboticsDefTool
{
    public class DeviceRoutingEntity : IComparable<DeviceRoutingEntity>
    {
        public string DeviceId { get; set; }
        public string RoutingKeyword { get; set; }
        public string TargetType { get; set; }
        public string TargetDeviceGroupId { set; get; }
        public string TargetDeviceId { set; get; }
        public string Status { set; get; }
        public string Description { set; get; }
        public DateTime Registered_DateTime { set; get; }

        public int CompareTo(DeviceRoutingEntity other)
        {
            return string.Compare(this.DeviceId + this.RoutingKeyword, other.DeviceId + other.RoutingKeyword
                , StringComparison.OrdinalIgnoreCase);
        }

    }
}
