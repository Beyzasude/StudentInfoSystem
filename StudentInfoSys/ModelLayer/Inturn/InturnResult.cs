using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Inturn
{
    public class InturnResult
    {
        public int InturnID { get; set; }
        public string InturnName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalTime { get; set; }
        public int Status { get; set; }

    }
}
