using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Devices;

namespace CloudRoboticsUtil
{
    public class C2dMessageSender
    {
        private JArray _ja_messages;
        private string _iotHubConnString;
        private string _sqlConnString;
        public C2dMessageSender(JArray ja_messages, string iotHubConnString, string sqlConnString)
        {
            _ja_messages = ja_messages;
            _iotHubConnString = iotHubConnString;
            _sqlConnString = sqlConnString;
        }
        public async void SendToDevice()
        {
            foreach (JObject jo in _ja_messages)
            {
                JObject jo_header = (JObject)jo[RbFormatType.RbHeader];
                string jo_TargetType = (string)jo_header["TargetType"];
                string jo_TargetDeviceGroupId = (string)jo_header["TargetDeviceGroupId"];
                string jo_TargetDeviceId = (string)jo_header["TargetDeviceId"];
                string msg = JsonConvert.SerializeObject(jo);
                if (jo_TargetType == RbTargetType.Device)
                {
                    var sendMessage = new Message(Encoding.UTF8.GetBytes(msg));
                    ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(_iotHubConnString);
                    await serviceClient.SendAsync(jo_TargetDeviceId, sendMessage);
                    await serviceClient.CloseAsync();
                }
                else
                {
                    DeviceGroup dg = new DeviceGroup(jo_TargetDeviceGroupId, _sqlConnString);
                    List<string> deviceList = dg.GetDeviceGroupList();
                    ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(_iotHubConnString);
                    var sendMessage = new Message(Encoding.UTF8.GetBytes(msg));
                    foreach (string deviceId in deviceList)
                    {
                        await serviceClient.SendAsync(deviceId, sendMessage);
                    }
                    await serviceClient.CloseAsync();
                }
            }
        }

        public async void SendToEachDevice(List<string> deviceList, int position)
        {
            foreach (JObject jo in _ja_messages)
            {
                JObject jo_header = (JObject)jo[RbFormatType.RbHeader];
                string jo_TargetType = (string)jo_header["TargetType"];
                string jo_TargetDeviceGroupId = (string)jo_header["TargetDeviceGroupId"];
                string jo_TargetDeviceId = (string)jo_header["TargetDeviceId"];
                string msg = JsonConvert.SerializeObject(jo);
                var sendMessage = new Message(Encoding.UTF8.GetBytes(msg));
                ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(_iotHubConnString);
                string deviceId = deviceList[position];
                await serviceClient.SendAsync(deviceId, sendMessage);
                await serviceClient.CloseAsync();
            }
        }
    }
}
