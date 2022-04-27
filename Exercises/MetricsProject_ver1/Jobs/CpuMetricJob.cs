using MetricsProject_ver1.Client;
using MetricsProject_ver1.DAL.Models.Agents;
using MetricsProject_ver1.DAL.Repositories.IAgentsRepositories;
using MetricsProject_ver1.DAL.Repositories.MetricsRepositories;
using MetricsProject_ver1.DTO;
using MetricsProject_ver1.Requests;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.Jobs
{
    public class CpuMetricJob
    {
        private ICpuMetricsRepository _repository;
        private IAgentRepository _agentsRepository;
        private IMetricsAgentClient _clientAgent;

        public CpuMetricJob(ICpuMetricsRepository repository, IAgentRepository agentsRepository, IMetricsAgentClient clientAgent)
        {
            _repository = repository;
            _agentsRepository = agentsRepository;
            _clientAgent = clientAgent;
        }


        public Task Execute(IJobExecutionContext context)
        {

            var agents = _agentsRepository.GetAllAgents();

            foreach (AgentModel agent in agents)
            {
                var metrics = _clientAgent.GetCpuMetrics(new GetAllCpuMetricsApiRequest()
                {
                    fromTime = DateTimeOffset.UtcNow.ToLocalTime(),
                    toTime = DateTimeOffset.UtcNow.AddHours(-5),
                    ClientBaseAddress = agent.AgentUrl});
                }

            return Task.CompletedTask;

        }
    }
}
