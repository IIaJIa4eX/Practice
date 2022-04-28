﻿using MetricsProject_ver1.Requests;
using MetricsProject_ver1.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MetricsProject_ver1.Client
{
    public class MetricsAgentClient : IMetricsAgentClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MetricsAgentClient> _logger;
        public MetricsAgentClient(HttpClient httpClient, ILogger<MetricsAgentClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }


        public IList<AllHddMetricsApiResponse> GetAllHddMetrics(GetAllHddMetricsApiRequest request)
        {
            var fromParameter = request.fromTime;
            var toParameter = request.toTime;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{request.ClientBaseAddress}/api/hddmetrics/from/{fromParameter}/to/{toParameter}");

            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<IList<AllHddMetricsApiResponse>>(responseStream).Result ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }   
      

        public AllRamMetricsApiResponse GetAllRamMetrics(GetAllRamMetricsApiRequest request)
        {
            throw new NotImplementedException();
        }

        public IList<AllCpuMetricsApiResponse> GetCpuMetrics(GetAllCpuMetricsApiRequest request)
        {
            var fromParameter = request.fromTime;
            var toParameter = request.toTime;
            var httpRequest = new HttpRequestMessage
                (
                HttpMethod.Get,
                $"{request.ClientBaseAddress}/api/cpumetricsagent/getbytimeperiod/from/{fromParameter}/to/{toParameter}"
                );

            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<IList<AllCpuMetricsApiResponse>>(responseStream).Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public IList<DonNetMetricsApiResponse> GetDonNetMetrics(DonNetHeapMetrisApiRequest request)
        {
            throw new NotImplementedException();
        }

        public AllNetWorkMetricsApiResponse GetNetWorkMetrics(GetAllNetWorkTrafficMetricsApiRequest request)
        {
            throw new NotImplementedException();
        }
    }
}