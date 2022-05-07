using AutoMapper;
using MetricsAgent.DAL;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using MetricsAgent.Requests.RamMetricRequests;
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
    public class RamMetricsAgentController : ControllerBase
    {

        private IRamMetricsRepository _repository;
        private readonly ILogger<RamMetricsAgentController> _logger;
        private readonly IMapper _mapper;

        public RamMetricsAgentController(IRamMetricsRepository repository, ILogger<RamMetricsAgentController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }



        [HttpGet("available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetAvailableRamMetrics(
        [FromRoute] TimeSpan fromTime,
        [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"Данные метода GetAvailableRamMetrics в RamMetricsAgentController: {fromTime}, {toTime}");
            return Ok();
        }



        /// <summary>
        /// Создать метрику RAM
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST api/rammetricsagent/create
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
        public IActionResult Create([FromBody] RamMetricCreateRequest request)
        {
            _logger.LogInformation($"Данные метода Create в RamMetricsAgentController: {request.Time}, {request.Value}");
            _repository.Create(new RamMetric
            {
                Time = request.Time,
                Value = request.Value
            });
            return Ok();
        }



        /// <summary>
        /// Получает все метрики RAM, за всё время
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// GET api/rammetricsagent/all
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

            IList<RamMetric> metrics = _repository.GetAll();
            var response = new AllRamMetricsResponse()
            {
                Metrics = new List<RamMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<RamMetricDto>(metric));
            }

            _logger.LogInformation($"Отработал метод GetAll");
            return Ok(response.Metrics);
        }



        /// <summary>
        /// Получает метрики RAM на заданном диапазоне времени
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// GET api/rammetricsagent/getbytimeperiod/from/2022-05-03T12:22:55+03:00/to/2022-05-03T12:26:40+03:00
        ///
        /// </remarks>
        /// <param name="fromTime">начальная метрика времени в формате 2022-01-01T00:00:00+03:00</param>
        /// <param name="toTime">конечная метрика времени в секундах с 2099-01-01T00:00:00+03:00</param>
        /// <returns>Список метрик, сохранённых в заданном диапазоне времени</returns>
        /// <response code="201">Если всё хорошо</response>
        /// <response code="400">Если передали неправильные параметры</response>
        /// 
        [HttpGet("getbytimeperiod/from/{fromTime}/to/{toTime}")]
        public IActionResult GetByTimePeriod([FromRoute] RamMetricGetByTimePeriodRequest req)
        {
            _logger.LogInformation($"Данные метода GetByTimePeriod в RamMetricsAgentController: {req.fromTime}, {req.toTime}");

            try
            {
                var metrics = _repository.GetByTimePeriod(req.fromTime, req.toTime);
                var response = new AllRamMetricsResponse()
                {
                    Metrics = new List<RamMetricDto>()
                };
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<RamMetricDto>(metric));
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
        /// Получает последнюю метрику Ram
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// GET api/rammetricsagent/getlastvalue
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
