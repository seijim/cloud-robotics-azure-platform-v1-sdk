using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudRoboWpfLoadTest
{
    public class ReplaceOperator
    {
        public string Id { set; get; }
        public string Mode { set; get; }
        public string Increment { set; get; }
        public string StartValue { set; get; }
        public string EndValue { set; get; }
    }

    public class ThreadInput
    {
        public int ThreadNo { set; get; }
        public int ThreadCount { set; get; }
        public string Message { set; get; }
        public string ParamDateTimeId { set; get; }
        public string ParamDateTimeValue { set; get; }
        public List<ReplaceOperator> ReplaceOperatorList { set; get; }
    }

    public class ThreadResult
    {
        public string DeviceId { set; get; }
        public int ThroughputPer60Sec { set; get; }
        public DateTime UpdateTime { set; get; }
        public bool IsEnabled { set; get; }
        public string ExceptionMessage { set; get; }
    }

}
