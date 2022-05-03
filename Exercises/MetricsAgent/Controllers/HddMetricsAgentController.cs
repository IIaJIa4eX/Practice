using AutoMapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using MetricsAgent.Requests.HddMetricRequests;
using MetricsAgent.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MetricsAgent.Controllers
{
     //to review
    [Route("api/[controller]")]
    [ApiController]
    public class HddMetricsAgentController : ControllerBase
    {
        private IHddMetricsRepository _repository;
        private readonly ILogger<HddMetricsAgentController> _logger;
        private readonly IMapper _mapper;


        public HddMetricsAgentController(ILogger<HddMetricsAgentController> logger, IHddMetricsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }

        [HttpGet("left/from/{fromTime}/to/{toTime}.")]
        public IActionResult GetHddMetrics(
        [FromRoute] TimeSpan fromTime,
        [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"Данные метода GetHddMetrics в HddMetricsAgentController: {fromTime}, {toTime}");
            return Ok();
        }


        /// <summary>
        /// Создать метрику Hdd
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST api/hddmetricsagent/create
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
        public IActionResult Create([FromBody] HddMetricCreateRequest request)
        {
            _logger.LogInformation($"Данные метода Create в HddMetricsAgentController: {request.Time}, {request.Value}");
            _repository.Create(new HddMetric
            {
                Time = request.Time,
                Value = request.Value
            });
            return Ok();
        }


        /// <summary>
        /// Получает все метрики HDD, за всё время
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// GET api/hddmetricsagent/all
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

            IList<HddMetric> metrics = _repository.GetAll();
            var response = new AllHddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<HddMetricDto>(metric));
            }

            _logger.LogInformation($"Отработал метод GetAll");
            return Ok(response.Metrics);
        }


        /// <summary>
        /// Получает метрики HDD на заданном диапазоне времени
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// GET api/hddmetricsagent/getbytimeperiod/from/2022-05-03T12:22:55+03:00/to/2022-05-03T12:26:40+03:00
        ///
        /// </remarks>
        /// <param name="fromTime">начальная метрика времени в формате 2022-01-01T00:00:00+03:00</param>
        /// <param name="toTime">конечная метрика времени в секундах с 2099-01-01T00:00:00+03:00</param>
        /// <returns>Список метрик, сохранённых в заданном диапазоне времени</returns>
        /// <response code="201">Если всё хорошо</response>
        /// <response code="400">Если передали неправильные параметры</response>
        /// 
        [HttpGet("getbytimeperiod/from/{fromTime}/to/{toTime}")]
        public IActionResult GetByTimePeriod([FromRoute] HddMetricGetByTimePeriodRequest req)
        {
            _logger.LogInformation($"Данные метода GetByTimePeriod в HddMetricsAgentController: {req.fromTime}, {req.toTime}");

            try
            {
                var metrics = _repository.GetByTimePeriod(req.fromTime, req.toTime);
                var response = new AllHddMetricsResponse()
                {
                    Metrics = new List<HddMetricDto>()
                };
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<HddMetricDto>(metric));
                }
                return Ok(response.Metrics);
            }
            catch
            {

            }
            _logger.LogInformation($"Отработал метод GetByTimePeriod");
            return Ok();
        }
    }
}
