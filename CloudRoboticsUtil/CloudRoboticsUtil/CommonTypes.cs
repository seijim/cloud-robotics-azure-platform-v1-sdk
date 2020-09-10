using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudRoboticsUtil
{
    public class RbRoutingType
    {
        public static string D2D { get { return "D2D"; } }
        public static string CALL { get { return "CALL"; } }
        public static string LOG { get { return "LOG"; } }
        public static string CONTROL { get { return "CONTROL"; } }
    }
    public class RbFormatType
    {
        public static string RbHeader { get { return "RbHeader"; } }
        public static string RbBody { get { return "RbBody"; } }
    }
    public class RbHeaderElement
    {
        public static string RoutingType { get { return "RoutingType"; } }
        public static string RoutingKeyword { get { return "RoutingKeyword"; } }
        public static string AppId { get { return "AppId"; } }
        public static string AppProcessingId { get { return "AppProcessingId"; } }
        public static string MessageId { get { return "MessageId"; } }
        public static string MessageSeqno { get { return "MessageSeqno"; } }
        public static string SendDateTime { get { return "SendDateTime"; } }
    }
    public class RbControlType
    {
        public static string ReqAppInfo { get { return "ReqAppInfo"; } }
        public static string ResAppInfo { get { return "ResAppInfo"; } }
    }
    public class RbExceptionMessage
    {
        public static string RbHeaderNotFound { get { return "Error ** RbHeader not found in message."; } }
    }
    public class RbTraceType
    {
        public static string Detail { get { return "Detail"; } }
        public static string Basic { get { return "Basic"; } }
    }
    public class RbAppCacheType
    {
        public static int DefaultCachingTimeSec { get { return 60; } }
    }
    public class RbTargetType
    {
        public static string Device { get { return "Device"; } }
        public static string DeviceGroup { get { return "DeviceGroup"; } }
    }
    public class RbMessageLogType
    {
        public static string C2dType { get { return "C2D_Messages"; } }
        public static string D2cFileUploadType { get { return "D2C_FileUpload"; } }
    }
}
