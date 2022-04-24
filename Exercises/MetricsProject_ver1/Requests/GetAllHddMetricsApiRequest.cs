using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.Requests
{
    public class GetAllHddMetricsApiRequest : CommonClientInfo
    {
        public string ClientBaseAddress = hdd_ClientAddress;
        public DateTimeOffset fromTime { get; set; }

        public DateTimeOffset toTime { get; set; }
    }
}
