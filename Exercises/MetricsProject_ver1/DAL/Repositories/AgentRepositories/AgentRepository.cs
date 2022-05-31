using Dapper;
using MetricsProject_ver1.DAL.Models.Agents;
using MetricsProject_ver1.DAL.Repositories.IAgentsRepositories;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.DAL.Repositories.AgentRepositories
{
    public class AgentRepository : IAgentRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;";



        public AgentModel GetAgentById(long id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle<AgentModel>("SELECT * FROM Agents WHERE AgentId = @agentId",
                    new
                    {
                        agentId = id
                    });
            }
        }

        public List<AgentModel> GetAllAgents()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<AgentModel>("SELECT * FROM Agents").ToList();
            }
        }

        public void SetNewAgent(AgentModel item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {

                connection.Execute("INSERT INTO Agents (AgentUrl) VALUES(@value)",
                new
                {
                    value = item.AgentUrl,
                });
            }
        }
    }
}
