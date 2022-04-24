using MetricsProject_ver1.Requests;
using MetricsProject_ver1.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.Client
{
    public interface IMetricsAgentClient
    {
        AllRamMetricsApiResponse GetAllRamMetrics(GetAllRamMetricsApiRequest request);
        AllHddMetricsApiResponse GetAllHddMetrics(GetAllHddMetricsApiRequest request);
        DonNetMetricsApiResponse GetDonNetMetrics(DonNetHeapMetrisApiRequest request);
        AllCpuMetricsApiResponse GetCpuMetrics(GetAllCpuMetricsApiRequest request);
        AllNetWorkMetricsApiResponse GetNetWorkMetrics(GetAllNetWorkTrafficMetricsApiRequest request);
    }
}
