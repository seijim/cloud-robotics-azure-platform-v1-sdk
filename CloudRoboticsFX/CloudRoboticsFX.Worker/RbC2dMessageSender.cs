using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Devices;
using CloudRoboticsUtil;

namespace CloudRoboticsFX.Worker
{
    public class RbC2dMessageSender
    {
        private JArray ja_messages;
        private string iotHubConnString;
        private string sqlConnString;
        public RbC2dMessageSender(JArray ja_messages, string iotHubConnString, string sqlConnString)
        {
            this.ja_messages = ja_messages;
            this.iotHubConnString = iotHubConnString;
            this.sqlConnString = sqlConnString;
        }
        public async void SendToDevice()
        {
            foreach (JObject jo in ja_messages)
            {
                JObject jo_header = (JObject)jo[RbFormatType.RbHeader];
                string jo_TargetType = (string)jo_header["TargetType"];
                string jo_TargetDeviceGroupId = (string)jo_header["TargetDeviceGroupId"];
                string jo_TargetDeviceId = (string)jo_header["TargetDeviceId"];
                string msg = JsonConvert.SerializeObject(jo);
                if (jo_TargetType == RbTargetType.Device)
                {
                    var sendMessage = new Message(Encoding.UTF8.GetBytes(msg));
                    ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(iotHubConnString);
                    await serviceClient.SendAsync(jo_TargetDeviceId, sendMessage);
                    await serviceClient.CloseAsync();
                }
                else
                {
                    DeviceGroup dg = new DeviceGroup(jo_TargetDeviceGroupId, sqlConnString);
                    List<string> deviceList = dg.GetDeviceGroupList();
                    ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(iotHubConnString);
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
            foreach (JObject jo in ja_messages)
            {
                JObject jo_header = (JObject)jo[RbFormatType.RbHeader];
                string jo_TargetType = (string)jo_header["TargetType"];
                string jo_TargetDeviceGroupId = (string)jo_header["TargetDeviceGroupId"];
                string jo_TargetDeviceId = (string)jo_header["TargetDeviceId"];
                string msg = JsonConvert.SerializeObject(jo);
                var sendMessage = new Message(Encoding.UTF8.GetBytes(msg));
                ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(iotHubConnString);
                string deviceId = deviceList[position];
                await serviceClient.SendAsync(deviceId, sendMessage);
                await serviceClient.CloseAsync();
            }
        }
    }
}
