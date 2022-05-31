using MetricsProject_ver1.DAL.Models.Agents;
using MetricsProject_ver1.DAL.Repositories.IAgentsRepositories;
using MetricsProject_ver1.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   
    public class AgentsController : ControllerBase
    {
        IAgentRepository _repository;
        public AgentsController(IAgentRepository repository)
        {
            _repository = repository;
        }


        [HttpPost("agentregistration")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            try
            {
                _repository.SetNewAgent(new AgentModel() { AgentUrl = agentInfo.AgentAddress });
            }
            catch(Exception ex)
            {
                return Ok("Что-то пошло не так" + ex.Message);
            }
            return Ok();
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }

        [HttpGet("getobjets")]
        public IActionResult GetRegisteredObjectsList()
        {
            var agents = _repository.GetAllAgents();
            return Ok(agents);
        }

    }

}

