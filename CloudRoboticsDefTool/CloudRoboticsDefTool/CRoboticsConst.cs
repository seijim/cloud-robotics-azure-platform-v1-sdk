using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudRoboticsDefTool
{
    public class CRoboticsConst
    {
        public static readonly List<string> DeviceTypeList 
            = new List<string> { "Pepper","Surface Hub","Surface","Digital Signage","Sensor","other device","app" };

        public static readonly List<string> StatusList
            = new List<string> { "Active", "NA" };

        public static readonly string RoutingKeywordDefault = "Default";

        public static readonly string StatusActive = "Active";

        public static readonly string StatusNoAvailable = "NA";

        public static readonly List<string> TargetDeviceTypeList
            = new List<string> { "DeviceGroup", "Device" };

        public static readonly string TypeDeviceGroup = "DeviceGroup";

        public static readonly string TypeDevice = "Device";

        public static readonly List<string> DevModeList
            = new List<string> { "False", "True" };

        public static readonly string TypeTrue = "True";

        public static readonly string TypeFalse = "False";

    }
}
