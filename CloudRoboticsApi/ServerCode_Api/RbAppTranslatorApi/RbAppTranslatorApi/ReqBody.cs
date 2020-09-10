using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbAppTranslatorApi
{
    public class ReqBody
    {
        public string visitor { set; get; }
        public string visitor_id { set; get; }
        public string text { set; get; }
        public string tolang { set; get; }
    }
}
