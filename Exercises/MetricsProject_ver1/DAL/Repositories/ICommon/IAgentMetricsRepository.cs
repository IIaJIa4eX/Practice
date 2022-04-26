using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.DAL.Repositories.ICommon
{
    interface IAgentMetricsRepository<T> where T : class
    {
        List<T> GetAllAgents();
        T GetAgentById(long id);
        void SetNewAgent(T item);

    }


}
