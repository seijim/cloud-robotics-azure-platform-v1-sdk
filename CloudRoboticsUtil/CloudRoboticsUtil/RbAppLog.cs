using System;
using System.Threading;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json.Linq;

namespace CloudRoboticsUtil
{
    public class RbAppLog
    {
        private string _connectionString;
        private string _tableName;
        private string _hostName;
        private string _appName;
        private CloudStorageAccount _storageAccount;
        private CloudTableClient _tableClient;
        private CloudTable _table;

        public void Initialize(string pConnectionString, string pTableName, string pAppName)
        {
            _connectionString = pConnectionString;
            _tableName = pTableName;
            _hostName = Environment.MachineName;
            _appName = pAppName;

            _storageAccount = CloudStorageAccount.Parse(_connectionString);
            _tableClient = _storageAccount.CreateCloudTableClient();
            _table = _tableClient.GetTableReference(_tableName);

            _table.CreateIfNotExists();
        }

        public void WriteLog(string message)
        {
            var data = new LogData();
            data.Category = "Info";
            data.MessageNo = "LOG";
            data.MessageText = message;
            WriteLogData(data);

        }

        public void WriteLog(string message, JObject jsonData)
        {
            var data = new LogData();
            data.Category = "Info";
            data.MessageNo = "LOG";
            data.MessageText = message;
            data.Data = jsonData.ToString();
            WriteLogData(data);

        }

        public void WriteError(string messageNo, string message)
        {
            var data = new LogData();
            data.Category = "Error**";
            data.MessageNo = messageNo;
            data.MessageText = message;
            WriteLogData(data);

        }

        public void WriteError(string messageNo, string message, JObject jsonData)
        {
            var data = new LogData();
            data.Category = "Error**";
            data.MessageNo = messageNo;
            data.MessageText = message;
            data.Data = jsonData.ToString();
            WriteLogData(data);

        }
        public void WriteError(string messageNo, string message, Exception ex)
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

        public void WriteError(string messageNo, Exception ex)
        {
            var data = new LogData();
            data.Category = "Error**";
            data.MessageNo = messageNo;
            data.MessageText = ex.ToString();

            WriteLogData(data);
        }

        private void WriteLogData(LogData data)
        {
            TimeSpan ts = new TimeSpan(9, 0, 0);
            data.LocalDateTimeJP = DateTime.UtcNow + ts;
            data.HostName = _hostName;
            data.ThreadId = Thread.CurrentThread.ManagedThreadId;
            data.AppName = _appName;

            var operation = TableOperation.Insert(data);

            _table.ExecuteAsync(operation).Wait();
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
