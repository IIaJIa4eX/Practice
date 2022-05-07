using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsDeskTopClient.Requests
{
    public class DonNetHeapMetrisApiRequest 
    {
        public string ClientBaseAddress { get; set; }
        public DateTimeOffset fromTime { get; set; }

        public DateTimeOffset toTime { get; set; }
    }
}
