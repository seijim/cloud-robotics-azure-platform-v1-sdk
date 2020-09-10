using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Auth;
using Newtonsoft.Json.Linq;

namespace CloudRoboticsUtil
{
    public class RbTraceLog
    {
        private static string connectionString;
        private static string tableName;
        private static string hostName;
        private static string appName;

        public static void Initialize(string pConnectionString, string pTableName, string pAppName)
        {
            connectionString = pConnectionString;
            tableName = pTableName;
            hostName = Environment.MachineName;
            appName = pAppName;
        }

        public static void WriteLog(string message)
        {
            var data = new LogData();
            data.Category = "Info";
            data.MessageNo = "LOG";
            data.MessageText = message;
            WriteLogData(data);

        }

        public static void WriteLog(string message, JObject jsonData)
        {
            var data = new LogData();
            data.Category = "Info";
            data.MessageNo = "LOG";
            data.MessageText = message;
            data.Data = jsonData.ToString();
            WriteLogData(data);

        }

        public static void WriteError(string messageNo, string message)
        {
            var data = new LogData();
            data.Category = "Error**";
            data.MessageNo = messageNo;
            data.MessageText = message;
            WriteLogData(data);

        }

        public static void WriteError(string messageNo, string message, JObject jsonData)
        {
            var data = new LogData();
            data.Category = "Error**";
            data.MessageNo = messageNo;
            data.MessageText = message;
            data.Data = jsonData.ToString();
            WriteLogData(data);

        }
        public static void WriteError(string messageNo, string message, Exception ex)
        {
            var data = new LogData();
            data.Category = "Error**";
            data.MessageNo = messageNo;

            if (message.Length > 0)
                data.MessageText = message + " : " + ex.ToString();
            else
                data.MessageText = ex.ToString();

            WriteLogData(data);

        }

        public static void WriteError(string messageNo, Exception ex)
        {
            var data = new LogData();
            data.Category = "Error**";
            data.MessageNo = messageNo;
            data.MessageText = ex.ToString();

            WriteLogData(data);
        }

        public static void CreateLogTableIfNotExists()
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference(tableName);

            table.CreateIfNotExists();
        }

        private static void WriteLogData(LogData data)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference(tableName);

            TimeSpan ts = new TimeSpan(9, 0, 0);
            data.LocalDateTimeJP = DateTime.UtcNow + ts;
            data.HostName = hostName;
            data.ThreadId = Thread.CurrentThread.ManagedThreadId;
            data.AppName = appName;

            var operation = TableOperation.Insert(data);

            table.ExecuteAsync(operation).Wait();
        }

        public class LogData : TableEntity
        {
            public LogData()
            {
                DateTime today = DateTime.UtcNow;
                this.PartitionKey = String.Format("{0:d04}{1:d02}{2:d02}", today.Year, today.Month, today.Day);
                this.RowKey = String.Format("{0:d04}{1:d02}{2:d02}{3:d02}{4:d02}{5:d02}{6:d04}", today.Year, today.Month, today.Day, today.Hour, today.Minute, today.Second, today.Millisecond) + "_" + Guid.NewGuid().ToString();
            }

            public DateTime LocalDateTimeJP { get; set; }
            public string HostName { get; set; }
            public int ThreadId { get; set; }
            public string Category { get; set; }
            public string AppName { get; set; }
            public string MessageNo { get; set; }
            public string MessageText { get; set; }
            public string Data { get; set; }
        }
    }
}
