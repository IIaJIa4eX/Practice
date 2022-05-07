using MetricsDeskTopClient.Requests;
using MetricsDeskTopClient.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace MetricsDeskTopClient.Client
{
    //to review
    public class MetricsAgentClient : IMetricsAgentClient
    {
        private readonly HttpClient _httpClient;
        
        public MetricsAgentClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public AllCpuMetricsApiResponse GetLastCpuMetrics(GetAllCpuMetricsApiRequest request)
        {

            var httpRequest = new HttpRequestMessage
                (
                HttpMethod.Get,
                $"{request.ClientBaseAddress}/api/cpumetricsagent/getlastvalue");

            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;

                return JsonSerializer.DeserializeAsync<AllCpuMetricsApiResponse>
                    (
                    responseStream,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                    ).Result;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public DonNetMetricsApiResponse GetLastDonNetMetrics(DonNetHeapMetrisApiRequest request)
        {
            var httpRequest = new HttpRequestMessage
               (
               HttpMethod.Get,
               $"{request.ClientBaseAddress}/api/dotnetmetricsagent/getlastvalue");

            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;

                return JsonSerializer.DeserializeAsync<DonNetMetricsApiResponse>
                    (
                    responseStream,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                    ).Result;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public AllHddMetricsApiResponse GetLastHddMetrics(GetAllHddMetricsApiRequest request)
        {
            var httpRequest = new HttpRequestMessage
               (
               HttpMethod.Get,
               $"{request.ClientBaseAddress}/api/hddmetricsagent/getlastvalue");

            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;

                return JsonSerializer.DeserializeAsync<AllHddMetricsApiResponse>
                    (
                    responseStream,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                    ).Result;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public AllNetWorkMetricsApiResponse GetLastNetWorkMetrics(GetAllNetWorkTrafficMetricsApiRequest request)
        {
            var httpRequest = new HttpRequestMessage
               (
               HttpMethod.Get,
               $"{request.ClientBaseAddress}/api/networkmetricsagent/getlastvalue");

            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;

                return JsonSerializer.DeserializeAsync<AllNetWorkMetricsApiResponse>
                    (
                    responseStream,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                    ).Result;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public AllRamMetricsApiResponse GetLastRamMetrics(GetAllRamMetricsApiRequest request)
        {
            var httpRequest = new HttpRequestMessage
              (
              HttpMethod.Get,
              $"{request.ClientBaseAddress}/api/rammetricsagent/getlastvalue");

            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;

                return JsonSerializer.DeserializeAsync<AllRamMetricsApiResponse>
                    (
                    responseStream,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                    ).Result;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
