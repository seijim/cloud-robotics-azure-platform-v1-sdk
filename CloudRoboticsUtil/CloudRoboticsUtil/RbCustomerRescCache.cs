using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudRoboticsUtil
{
    [Serializable]
    public class RbCustomerRescCache
    {
        public string CustomerId { set; get; }
        public string ResourceGroupId { set; get; }
        public string SqlConnectionString { set; get; }  // Each database to store customer data in an elastic database pool
        public string Description { set; get; }
        public DateTime Registered_DateTime { set; get; }
        public DateTime CacheExpiredDatetime { set; get; }
    }
}
