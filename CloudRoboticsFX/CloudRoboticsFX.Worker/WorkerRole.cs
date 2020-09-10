using System.Diagnostics;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.ServiceBus.Messaging;
using Microsoft.Azure;
using CloudRoboticsUtil;

namespace CloudRoboticsFX.Worker
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        private EventProcessorHost eventProcessorHost;
        private string iotHubConnectionString = string.Empty;
        private string iotHubClassicConnString = string.Empty;
        private string iotHubName = string.Empty;
        private string iotHubConsumerGroupName = string.Empty;
        private string storageQueueSendEnabled = string.Empty;
        private string storageAccountName = string.Empty;
        private string storageAccountKey = string.Empty;
        private string storageConnectionString = string.Empty;
        private string c2dLogEnabled = string.Empty;
        private string c2dLogEventHubConnString = string.Empty;
        private string traceStorageAccountName = string.Empty;
        private string traceStorageAccountKey = string.Empty;
        private string traceStorageConnectionString = string.Empty;
        private string traceTableName = string.Empty;
        private string traceLevel = string.Empty;
        private string eventProcessorHostName = string.Empty;
        private string archivedDirectoryName = "RBFX_ArchivedDll";

        public override bool OnStart()
        {
            // Max connection Limit
            ServicePointManager.DefaultConnectionLimit = 16;

            // Get properties
            iotHubConnectionString = CloudConfigurationManager.GetSetting("IoTHub.ConnectionString");
            iotHubClassicConnString = CloudConfigurationManager.GetSetting("IoTHub.ClassicConnectionString");
            int pos = iotHubClassicConnString.IndexOf("sb://");
            if (pos == 0)
            {
                int pos2 = iotHubConnectionString.IndexOf("SharedAccessKeyName=");
                string sharedAccessKey = iotHubConnectionString.Substring(pos2);
                iotHubClassicConnString = "Endpoint=" + iotHubClassicConnString + ";" + sharedAccessKey;
            }
            iotHubName = CloudConfigurationManager.GetSetting("IoTHub.HubName");
            iotHubConsumerGroupName = CloudConfigurationManager.GetSetting("IoTHub.ConsumerGroupName");
            storageAccountName = CloudConfigurationManager.GetSetting("IoTHub.StorageAccountName");
            storageAccountKey = CloudConfigurationManager.GetSetting("IoTHub.StorageAccountKey");
            storageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                        storageAccountName, storageAccountKey);
            storageQueueSendEnabled = CloudConfigurationManager.GetSetting("StorageQueue.SendEnabled");

            c2dLogEnabled = CloudConfigurationManager.GetSetting("RbC2dLog.Enable");

            traceStorageAccountName = CloudConfigurationManager.GetSetting("RbTrace.StorageAccountName");
            traceStorageAccountKey = CloudConfigurationManager.GetSetting("RbTrace.StorageAccountKey");
            traceStorageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                        traceStorageAccountName, traceStorageAccountKey);
            traceTableName = CloudConfigurationManager.GetSetting("RbTrace.StorageTableName");
            traceLevel = CloudConfigurationManager.GetSetting("RbTrace.TraceLevel");

            // Set properties to Event Processor
            if (c2dLogEnabled != null && c2dLogEnabled.ToLower() == "true")
            {
                RoboticsEventProcessor.rbC2dLogEnabled = true;
                RoboticsEventProcessor.rbC2dLogEventHubConnString = CloudConfigurationManager.GetSetting("RbC2dLog.EventHubConnString");
                RoboticsEventProcessor.rbC2dLogEventHubName = CloudConfigurationManager.GetSetting("RbC2dLog.EventHubName");
            }
            else
            {
                RoboticsEventProcessor.rbC2dLogEnabled = false;
            }
            RoboticsEventProcessor.rbTraceStorageConnString = traceStorageConnectionString;
            RoboticsEventProcessor.rbTraceTableName = traceTableName;
            RoboticsEventProcessor.rbTraceLevel = traceLevel;
            RoboticsEventProcessor.rbIotHubConnString = iotHubConnectionString;
            if (storageQueueSendEnabled != null && storageQueueSendEnabled.ToLower() == "true")
            {
                RoboticsEventProcessor.rbStorageQueueSendEnabled = true;
                RoboticsEventProcessor.rbStorageQueueConnString = storageConnectionString;
            }
            else
            {
                RoboticsEventProcessor.rbStorageQueueSendEnabled = false;
            }
            RoboticsEventProcessor.rbSqlConnectionString = CloudConfigurationManager.GetSetting("SqlConnectionString");
            RoboticsEventProcessor.rbEncPassPhrase = CloudConfigurationManager.GetSetting("RbEnc.PassPhrase");
            RoboticsEventProcessor.rbCacheExpiredTimeSec = int.Parse(CloudConfigurationManager.GetSetting("RbCache.ExpiredTimeSec"));
            RoboticsEventProcessor.archivedDirectoryName = archivedDirectoryName;

            // Event Processor Host
            string eventProcessorHostName = RoleEnvironment.CurrentRoleInstance.Id;
            eventProcessorHost = new EventProcessorHost(eventProcessorHostName, iotHubName, iotHubConsumerGroupName,
                                                        iotHubClassicConnString, storageConnectionString);

            RbTraceLog.Initialize(traceStorageConnectionString, traceTableName, "CloudRoboticsFX");
            RbTraceLog.CreateLogTableIfNotExists();

            bool result = base.OnStart();
            RbTraceLog.WriteLog("CloudRoboticsWorker has been started");

            return result;
        }
        public override void Run()
        {
            RbTraceLog.WriteLog("CloudRoboticsWoker is running");

            // Delete archived DLL directory
            string archivedDirectory = Environment.CurrentDirectory + @"\" + archivedDirectoryName;
            if (Directory.Exists(archivedDirectory))
            {
                Directory.Delete(archivedDirectory, true);
            }

            // Event Processor Host
            eventProcessorHost.RegisterEventProcessorAsync<RoboticsEventProcessor>();

            //Wait for shutdown to be called, else the role will recycle
            this.runCompleteEvent.WaitOne();

        }
        public override void OnStop()
        {
            RbTraceLog.WriteLog("CloudRoboticsWoker is stopping");

            this.runCompleteEvent.Set();
            eventProcessorHost.UnregisterEventProcessorAsync().Wait();

            base.OnStop();

            RbTraceLog.WriteLog("CloudRoboticsWoker has stopped");
        }
        private async Task RunAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                RbTraceLog.WriteLog("Working");
                await Task.Delay(1000);
            }
        }
    }
}
