using MetricsProject_ver1.Client;
using MetricsProject_ver1.DAL.Models;
using MetricsProject_ver1.DAL.Models.Agents;
using MetricsProject_ver1.DAL.Repositories.IAgentsRepositories;
using MetricsProject_ver1.DAL.Repositories.MetricsRepositories;
using MetricsProject_ver1.Requests;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.Jobs
{
    //to review
    public class HddMetricJob : IJob
    {
        private IHddMetricsRepository _repository;
        private IAgentRepository _agentsRepository;
        private IMetricsAgentClient _clientAgent;

        public HddMetricJob(IHddMetricsRepository repository, IAgentRepository agentsRepository, IMetricsAgentClient clientAgent)
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
                var fromTime = _repository.GetLastMetric(agent.AgentId).ToLocalTime();

                var metrics = _clientAgent.GetAllHddMetrics(new GetAllHddMetricsApiRequest()
                {

                    fromTime = fromTime.AddSeconds(1),
                    toTime = DateTimeOffset.UtcNow.ToLocalTime(),
                    ClientBaseAddress = agent.AgentUrl
                });
                if (metrics != null)
                {
                    foreach (var metric in metrics)
                    {
                        _repository.AddMetric(new HddMetric() { Value = metric.Value, Time = metric.Time, agentId = agent.AgentId });
                    }
                }
            }



            return Task.CompletedTask;

        }
    }
}
