using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;


namespace CloudRoboticsDefTool
{
    public class FxTraceLogProcessor
    {
        private string storageAccount;
        private string storageKey;
        private string tableName;
        private string storageConnectionString;

        public FxTraceLogProcessor(string storageAccount, string storageKey, string tableName)
        {
            this.storageAccount = storageAccount;
            this.storageKey = storageKey;
            this.tableName = tableName;
            this.storageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                        storageAccount, storageKey);
        }

        public List<FxTraceLogDsiplayEntity> GetFxTraceLogs(string dateString)
        {
            List<FxTraceLogDsiplayEntity> listFxTraceLogs = new List<FxTraceLogDsiplayEntity>();

            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference(tableName);
            TableQuery<FxTraceLogEntity> query = 
                new TableQuery<FxTraceLogEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, dateString));

            foreach (FxTraceLogEntity entity in table.ExecuteQuery(query))
            {
                var displayEntity = new FxTraceLogDsiplayEntity();
                displayEntity.PartitionKey = entity.PartitionKey;
                displayEntity.RowKey = entity.RowKey;
                displayEntity.LocalDateTimeJP = entity.LocalDateTimeJP.ToString("yyyy-MM-dd HH:mm:ss.fff");
                displayEntity.HostName = entity.HostName;
                displayEntity.ThreadId = entity.ThreadId;
                displayEntity.Category = entity.Category;
                displayEntity.AppName = entity.AppName;
                displayEntity.MessageNo = entity.MessageNo;
                displayEntity.MessageText = entity.MessageText;
                displayEntity.Data = entity.Data;

                listFxTraceLogs.Add(displayEntity);
            }

            return listFxTraceLogs;
        }

    }
}
