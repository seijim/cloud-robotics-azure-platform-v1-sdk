using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudRoboticsDefTool
{
    public class FxTraceLogDsiplayEntity : IComparable<FxTraceLogDsiplayEntity>
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string LocalDateTimeJP { get; set; }
        public string HostName { get; set; }
        public int ThreadId { get; set; }
        public string Category { get; set; }
        public string AppName { get; set; }
        public string MessageNo { get; set; }
        public string MessageText { get; set; }
        public string Data { get; set; }

        public int CompareTo(FxTraceLogDsiplayEntity other)
        {
            return string.Compare(this.RowKey, other.RowKey
                , StringComparison.OrdinalIgnoreCase);
        }
    }
}
