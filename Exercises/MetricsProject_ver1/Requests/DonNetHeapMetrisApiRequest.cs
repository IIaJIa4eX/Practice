using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.Requests
{
    public class DonNetHeapMetrisApiRequest : CommonClientInfo
    {
        public string ClientBaseAddress = dotnet_ClientAddress;
        public DateTimeOffset fromTime { get; set; }

        public DateTimeOffset toTime { get; set; }
    }
}
