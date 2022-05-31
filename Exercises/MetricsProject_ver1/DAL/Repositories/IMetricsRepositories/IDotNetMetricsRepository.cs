using MetricsProject_ver1.DAL.Models;
using MetricsProject_ver1.DAL.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.DAL.Repositories.MetricsRepositories
{
    public interface IDotNetMetricsRepository : IMetricsRepository<DotNetMetric>
    {
    }
}

