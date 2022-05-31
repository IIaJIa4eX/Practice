using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.DAL.Repositories.Common
{
     public interface IMetricsRepository<T> where T : class
    {

        void AddMetric(T item);
        IList<T> GetAgentMetricById(int id);

        IList<T> GetMetricsFromAllCluster();

        IList<T> GetMetricsByTimePeriod(DateTimeOffset item, DateTimeOffset item2);

        DateTimeOffset GetLastMetric(long id);
    }

}
