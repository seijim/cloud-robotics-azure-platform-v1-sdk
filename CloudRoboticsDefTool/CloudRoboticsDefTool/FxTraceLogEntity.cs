using System;
using Microsoft.WindowsAzure.Storage.Table;


namespace CloudRoboticsDefTool
{
    public class FxTraceLogEntity : TableEntity,IComparable<FxTraceLogEntity>
    {
        public DateTime LocalDateTimeJP { get; set; }
        public string HostName { get; set; }
        public int ThreadId { get; set; }
        public string Category { get; set; }
        public string AppName { get; set; }
        public string MessageNo { get; set; }
        public string MessageText { get; set; }
        public string Data { get; set; }

        public int CompareTo(FxTraceLogEntity other)
        {
            return string.Compare(this.RowKey, other.RowKey
                , StringComparison.OrdinalIgnoreCase);
        }

    }
}
