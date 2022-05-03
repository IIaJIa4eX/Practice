using AutoMapper;
using Core;
using Dapper;
using MetricsAgent.DAL;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using MetricsAgent.Requests.CpuMetricRequests;
using MetricsAgent.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{

     //to review
    [Route("api/[controller]")]
    [ApiController]
    public class CpuMetricsAgentController : ControllerBase
    {

        private ICpuMetricsRepository _repository;
        private readonly ILogger<CpuMetricsAgentController> _logger;
        private readonly INotifierMediatorService _notifierMediatorService;
        private readonly IMapper _mapper;

        public CpuMetricsAgentController(ICpuMetricsRepository repository, ILogger<CpuMetricsAgentController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            
        }





        /// <summary>
        /// Создать метрику CPU
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST api/сpumetricsagent/create
        /// <param name="Time">метрика времени в формате 2022-01-01T00:00:00+03:00</param>
        /// Content-type - JSON
        /// Пример body запроса:
        /// {
        ///     "Value" = 100,
        ///     "Time" = "2022-05-03T12:22:55+03:00"
        /// }
        /// </remarks>
        /// 
        /// <returns>Создает указанную метрику, за указанное время</returns>
        /// <response code="201">Если всё хорошо</response>
        /// <response code="400">Если передали неправильные параметры</response>
        /// 
        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuMetricCreateRequest request)
        {
            _logger.LogInformation($"Данные метода Create в CpuMetricsAgentController: {request.Time}, {request.Value}");
            _repository.Create(new CpuMetric
            {
                Time = request.Time,
                Value = request.Value
            });
            return Ok();
        }



        /// <summary>
        /// Получает все метрики CPU, за всё время
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// GET api/сpumetricsagent/all
        ///
        /// </remarks>
        /// 
        /// <returns>Список метрик за всё время</returns>
        /// <response code="201">Если всё хорошо</response>
        /// <response code="400">Если передали неправильные параметры</response>
        /// 
        [HttpGet("all")]
        public IActionResult GetAll()
        {

            IList<CpuMetric> metrics = _repository.GetAll();
            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
            }

            _logger.LogInformation($"Отработал метод GetAll");
            return Ok(response.Metrics);
        }



        [HttpGet("metrics/cpu/from/{fromTime}/to/{toTime}")]
        public IActionResult GetCpuMetrics([FromRoute] CpuMetricGetByTimePeriodRequest req)
        {
            _logger.LogInformation($"Данные метода GetCpuMetrics в CpuMetricsAgentController: {req.fromTime}, {req.toTime}");
            return Ok();
        }



        /// <summary>
        /// Получает метрики CPU на заданном диапазоне времени
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// GET api/сpumetricsagent/getbytimeperiod/from/2022-05-03T12:22:55+03:00/to/2022-05-03T12:26:40+03:00
        ///
        /// </remarks>
        /// <param name="fromTime">начальная метрика времени в формате 2022-01-01T00:00:00+03:00</param>
        /// <param name="toTime">конечная метрика времени в секундах с 2099-01-01T00:00:00+03:00</param>
        /// <returns>Список метрик, сохранённых в заданном диапазоне времени</returns>
        /// <response code="201">Если всё хорошо</response>
        /// <response code="400">Если передали неправильные параметры</response>
        /// 
        [HttpGet("getbytimeperiod/from/{fromTime}/to/{toTime}")]
        public IActionResult GetByTimePeriod([FromRoute] CpuMetricGetByTimePeriodRequest req)
        {
            _logger.LogInformation($"Данные метода GetByTimePeriod в CpuMetricsAgentController: {req.fromTime}, {req.toTime}");

           
            
            try
            {
                var metrics = _repository.GetByTimePeriod(req.fromTime,req.toTime);
                var response = new AllCpuMetricsResponse()
                {
                    Metrics = new List<CpuMetricDto>()
                };
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
                }

                return Ok(response.Metrics);
            }
            catch
            {
                
            }

            _logger.LogInformation($"Отработал метод GetByTimePeriod");
            return null;
        }
    }
}
