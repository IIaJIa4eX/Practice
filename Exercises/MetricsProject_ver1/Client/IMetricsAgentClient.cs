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
        IList<AllRamMetricsApiResponse> GetAllRamMetrics(GetAllRamMetricsApiRequest request);
        IList<AllHddMetricsApiResponse> GetAllHddMetrics(GetAllHddMetricsApiRequest request);
        IList<DonNetMetricsApiResponse> GetDonNetMetrics(DonNetHeapMetrisApiRequest request);
        IList<AllCpuMetricsApiResponse> GetCpuMetrics(GetAllCpuMetricsApiRequest request);
        IList<AllNetWorkMetricsApiResponse> GetNetWorkMetrics(GetAllNetWorkTrafficMetricsApiRequest request);
    }
}
