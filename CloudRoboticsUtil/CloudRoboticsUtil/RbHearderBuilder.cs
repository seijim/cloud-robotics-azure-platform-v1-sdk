using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CloudRoboticsUtil
{
    public class RbHeaderBuilder
    {
        private ApplicationException ae;
        private JObject _message = null;
        private string _deviceId = null;
        private RbHeader _rbh;
        public RbHeaderBuilder(JObject message, string deviceId)
        {
            _message = message;
            _deviceId = deviceId;
        }
        public RbHeader ValidateJsonSchema()
        {
            JObject header = (JObject)_message[RbFormatType.RbHeader];
            _rbh = new RbHeader();
            if (header == null)
            {
                ae = new ApplicationException(RbExceptionMessage.RbHeaderNotFound);
                throw ae;
            }
            _rbh.RoutingType = (string)header[RbHeaderElement.RoutingType];
            if (_rbh.RoutingType == null)
            {
                ae = new ApplicationException("Error ** RbHeader[RoutingType] not found in message.");
                throw ae;
            }
            else if (_rbh.RoutingType.ToUpper() != RbRoutingType.CALL && _rbh.RoutingType.ToUpper() != RbRoutingType.D2D
                     && _rbh.RoutingType.ToUpper() != RbRoutingType.LOG && _rbh.RoutingType.ToUpper() != RbRoutingType.CONTROL)
            {
                ae = new ApplicationException("Error ** RbHeader[RoutingType] must be 'CALL' or 'D2D' or 'LOG' or 'CONTROL'.");
                throw ae;
            }
            _rbh.RoutingKeyword = (string)header[RbHeaderElement.RoutingKeyword];
            if (_rbh.RoutingKeyword == null || _rbh.RoutingKeyword == string.Empty)
            {
                _rbh.RoutingKeyword = "Default";
            }
            _rbh.AppId = (string)header["AppId"];
            if (_rbh.AppId == null)
            {
                ae = new ApplicationException("Error ** RbHeader[AppId] not found in message.");
                throw ae;
            }
            else if (_rbh.AppId == string.Empty)
            {
                ae = new ApplicationException("Error ** RbHeader[AppId] must be set.");
                throw ae;
            }
            _rbh.AppProcessingId = (string)header[RbHeaderElement.AppProcessingId];
            if (_rbh.AppProcessingId == null)
                _rbh.AppProcessingId = string.Empty;
            _rbh.MessageId = (string)header[RbHeaderElement.MessageId];
            if (_rbh.MessageId == null)
                _rbh.MessageId = string.Empty;
            _rbh.MessageSeqno = (long)header[RbHeaderElement.MessageSeqno];
            if (_rbh.MessageSeqno <= 0)
            {
                ae = new ApplicationException("Error ** RbHeader[MessageSeqno] must be larger than zero.");
                throw ae;
            }
            _rbh.SendDateTime = (DateTime)header[RbHeaderElement.SendDateTime];
            if (_rbh.SendDateTime == null)
            {
                ae = new ApplicationException("Error ** RbHeader[SendDateTime] not found in message.");
                throw ae;
            }
            _rbh.SourceDeviceId = _deviceId;
            _rbh.SourceDeviceType = string.Empty;
            _rbh.TargetType = string.Empty;
            _rbh.TargetDeviceGroupId = string.Empty;
            _rbh.TargetDeviceId = string.Empty;
            _rbh.ProcessingStack = string.Empty;

            return _rbh;
        }
    }
}
