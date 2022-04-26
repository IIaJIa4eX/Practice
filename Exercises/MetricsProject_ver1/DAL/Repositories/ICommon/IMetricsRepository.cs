using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.DAL.Repositories.Common
{
     public interface IMetricsRepository<T> where T : class
    {

        void AddMetric(T item);
        T GetAgentMetricById(int id);
    }

}
