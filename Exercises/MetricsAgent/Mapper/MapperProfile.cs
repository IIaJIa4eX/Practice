using AutoMapper;
using MetricsAgent.Models;
using MetricsAgent.Responses;

namespace MetricsAgent.Mapper
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricDto>();//.ConvertUsing(new CpuTypeConverter());
            CreateMap<DotNetMetric, DotNetMetricDto>();//.ConvertUsing(new DotNetTypeConverter());
            CreateMap<HddMetric, HddMetricDto>();//.ConvertUsing(new HddTypeConverter());
            CreateMap<NetWorkMetric, NetWorkMetricDto>();//.ConvertUsing(new NetWorkTypeConverter()); ;
            CreateMap<RamMetric, RamMetricDto>();//.ConvertUsing(new RamTypeConverter()); ;
        }


    }
}
