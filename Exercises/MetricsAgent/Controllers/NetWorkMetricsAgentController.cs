using AutoMapper;
using MetricsAgent.DAL;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using MetricsAgent.Requests.NetWorkMetricRequests;
using MetricsAgent.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    //to review
    [Route("api/[controller]")]
    [ApiController]
    public class NetWorkMetricsAgentController : ControllerBase
    {
        private INetWorkMetricsRepository _repository;
        private readonly ILogger<NetWorkMetricsAgentController> _logger;
        private readonly IMapper _mapper;

        public NetWorkMetricsAgentController(INetWorkMetricsRepository repository, ILogger<NetWorkMetricsAgentController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }

        [HttpGet("api/metrics/network/from/{fromTime}/to/{toTime}")]
        public IActionResult GetNetWorkMetrics(
        [FromRoute] TimeSpan fromTime,
        [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"Данные метода GetNetWorkMetrics в NetWorkMetricsAgentController: {fromTime}, {toTime}");
            return Ok();
        }



        /// <summary>
        /// Создать метрику NetWork
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST api/networkmetricsagent/create
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
        public IActionResult Create([FromBody] NetWorkMetricCreateRequest request)
        {
            _logger.LogInformation($"Данные метода Create в NetWorkMetricsAgentController: {request.Time}, {request.Value}");
            _repository.Create(new NetWorkMetric
            {
                Time = request.Time,
                Value = request.Value
            });
            return Ok();
        }



        /// <summary>
        /// Получает все метрики NetWork, за всё время
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// GET api/networkmetricsagent/all
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

            IList<NetWorkMetric> metrics = _repository.GetAll();
            var response = new AllNetWorkMetricsResponse()
            {
                Metrics = new List<NetWorkMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<NetWorkMetricDto>(metric));
            }

            _logger.LogInformation($"Отработал метод GetAll");
            return Ok(response.Metrics);
        }




        /// <summary>
        /// Получает метрики NetWork на заданном диапазоне времени
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// GET api/networkmetricsagent/getbytimeperiod/from/2022-05-03T12:22:55+03:00/to/2022-05-03T12:26:40+03:00
        ///
        /// </remarks>
        /// <param name="fromTime">начальная метрика времени в формате 2022-01-01T00:00:00+03:00</param>
        /// <param name="toTime">конечная метрика времени в секундах с 2099-01-01T00:00:00+03:00</param>
        /// <returns>Список метрик, сохранённых в заданном диапазоне времени</returns>
        /// <response code="201">Если всё хорошо</response>
        /// <response code="400">Если передали неправильные параметры</response>
        /// 
        [HttpGet("getbytimeperiod/from/{fromTime}/to/{toTime}")]
        public IActionResult GetByTimePeriod([FromRoute] NetWorkMetricGetByTimePeriodRequest req)
        {
            _logger.LogInformation($"Данные метода GetByTimePeriod в NetWorkMetricsAgentController: {req.fromTime}, {req.toTime}");

            try
            {
                var metrics = _repository.GetByTimePeriod(req.fromTime, req.toTime);
                var response = new AllNetWorkMetricsResponse()
                {
                    Metrics = new List<NetWorkMetricDto>()
                };
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<NetWorkMetricDto>(metric));

                }
                return Ok(response.Metrics);
            }
            catch
            {

            }
            _logger.LogInformation($"Отработал метод GetByTimePeriod");
            return Ok();
        }



        /// <summary>
        /// Получает последнюю метрику NetWork
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// GET api/networkmetricsagent/getlastvalue
        ///
        /// </remarks>
        /// 
        /// <returns>Последняя метрика</returns>
        /// <response code="201">Если всё хорошо</response>
        /// <response code="400">Если передали неправильные параметры</response>
        /// 
        [HttpGet("getlastvalue")]
        public IActionResult GetByTimePeriod()
        {

            try
            {
                var lastMetric = _repository.GetLastValue();
                return Ok(lastMetric);
            }
            catch
            {

            }
            return null;
        }
    }
}
