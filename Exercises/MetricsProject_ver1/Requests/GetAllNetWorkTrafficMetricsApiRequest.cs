using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.Requests
{
    public class GetAllNetWorkTrafficMetricsApiRequest : CommonClientInfo
    {
        public string ClientBaseAddress = network_ClientAddress;
        public DateTimeOffset fromTime { get; set; }

        public DateTimeOffset toTime { get; set; }
    }
}
