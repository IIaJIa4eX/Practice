﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.Requests
{
    public class GetAllRamMetricsApiRequest 
    {
        public string ClientBaseAddress { get; set; }
        public DateTimeOffset fromTime { get; set; }

        public DateTimeOffset toTime { get; set; }
    }
}
