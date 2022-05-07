using MetricsDeskTopClient.Requests;
using MetricsDeskTopClient.Responses;
using System.Collections.Generic;

namespace MetricsDeskTopClient.Client
{
    public interface IMetricsAgentClient
    {
        AllRamMetricsApiResponse GetLastRamMetrics(GetAllRamMetricsApiRequest request);
        AllHddMetricsApiResponse GetLastHddMetrics(GetAllHddMetricsApiRequest request);
        DonNetMetricsApiResponse GetLastDonNetMetrics(DonNetHeapMetrisApiRequest request);
        AllCpuMetricsApiResponse GetLastCpuMetrics(GetAllCpuMetricsApiRequest request);
        AllNetWorkMetricsApiResponse GetLastNetWorkMetrics(GetAllNetWorkTrafficMetricsApiRequest request);
    }
}
