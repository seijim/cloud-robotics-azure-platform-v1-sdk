using System;

namespace CloudRoboticsDefTool
{
    public class DeviceGroupEntity : IComparable<DeviceGroupEntity>
    {
        public string DeviceGroupId { get; set; }
        public string DeviceId { get; set; }
        public DateTime Registered_DateTime { get; set; }

        public int CompareTo(DeviceGroupEntity other)
        {
            return string.Compare(this.DeviceGroupId + this.DeviceId, other.DeviceGroupId + other.DeviceId
                , StringComparison.OrdinalIgnoreCase);
        }

    }
}
