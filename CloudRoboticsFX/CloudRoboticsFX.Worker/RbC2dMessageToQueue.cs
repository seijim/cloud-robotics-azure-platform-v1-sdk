using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.Azure.Devices;
using CloudRoboticsUtil;

namespace CloudRoboticsFX.Worker
{
    public class RbC2dMessageToQueue
    {
        private JArray ja_messages;
        private string sqlConnString;
        private string storageConnString;
        private CloudStorageAccount cloudStorageAccount;
        private CloudQueueClient cloudQueueClient;

        public RbC2dMessageToQueue(JArray ja_messages, string storageConnString, string sqlConnString)
        {
            this.ja_messages = ja_messages;
            this.sqlConnString = sqlConnString;
            this.storageConnString = storageConnString;
            this.cloudStorageAccount = CloudStorageAccount.Parse(storageConnString);
            this.cloudQueueClient = cloudStorageAccount.CreateCloudQueueClient();

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
                    CloudQueue cloudQueue = cloudQueueClient.GetQueueReference(jo_TargetDeviceId);
                    // Create the queue if it doesn't already exist
                    cloudQueue.CreateIfNotExists();
                    cloudQueue.AddMessage(new CloudQueueMessage(msg));
                }
                else
                {
                    DeviceGroup dg = new DeviceGroup(jo_TargetDeviceGroupId, sqlConnString);
                    List<string> deviceList = dg.GetDeviceGroupList();
                    foreach (string deviceId in deviceList)
                    {
                        CloudQueue cloudQueue = cloudQueueClient.GetQueueReference(deviceId);
                        // Create the queue if it doesn't already exist
                        cloudQueue.CreateIfNotExists();
                        await cloudQueue.AddMessageAsync(new CloudQueueMessage(msg));
                    }
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

                CloudQueue cloudQueue = cloudQueueClient.GetQueueReference(jo_TargetDeviceId);
                // Create the queue if it doesn't already exist
                cloudQueue.CreateIfNotExists();
                await cloudQueue.AddMessageAsync(new CloudQueueMessage(msg));
            }
        }

    }
}
