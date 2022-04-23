using AutoMapper;
using MetricsAgent.Models;
using MetricsAgent.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        
        //public class CpuTypeConverter : ITypeConverter<CpuMetric, CpuMetricDto>
        //{
            
        //    public CpuMetricDto Convert(CpuMetric source, CpuMetricDto destination, ResolutionContext context)
        //    {

        //        return new CpuMetricDto { Id = source.Id, Value = source.Value, Time = DateTimeOffset.FromUnixTimeSeconds((long)source.Time.TotalSeconds).ToLocalTime()};
        //    }
        //}

        //public class DotNetTypeConverter : ITypeConverter<DotNetMetric, DotNetMetricDto>
        //{


        //    public DotNetMetricDto Convert(DotNetMetric source, DotNetMetricDto destination, ResolutionContext context)
        //    {
        //        return new DotNetMetricDto { Id = source.Id, Value = source.Value, Time = DateTimeOffset.FromUnixTimeSeconds((long)source.Time.TotalSeconds).ToLocalTime() };
        //    }
        //}

        //public class HddTypeConverter : ITypeConverter<HddMetric, HddMetricDto>
        //{

        //    public HddMetricDto Convert(HddMetric source, HddMetricDto destination, ResolutionContext context)
        //    {
        //        return new HddMetricDto { Id = source.Id, Value = source.Value, Time = DateTimeOffset.FromUnixTimeSeconds((long)source.Time.TotalSeconds).ToLocalTime() };
        //    }
        //}

        //public class NetWorkTypeConverter : ITypeConverter<NetWorkMetric, NetWorkMetricDto>
        //{

        //    public NetWorkMetricDto Convert(NetWorkMetric source, NetWorkMetricDto destination, ResolutionContext context)
        //    {
        //        return new NetWorkMetricDto { Id = source.Id, Value = source.Value, Time = DateTimeOffset.FromUnixTimeSeconds((long)source.Time.TotalSeconds).ToLocalTime() };
        //    }
        //}

        //public class RamTypeConverter : ITypeConverter<RamMetric, RamMetricDto>
        //{

        //    public RamMetricDto Convert(RamMetric source, RamMetricDto destination, ResolutionContext context)
        //    {
        //        return new RamMetricDto { Id = source.Id, Value = source.Value, Time = DateTimeOffset.FromUnixTimeSeconds((long)source.Time.TotalSeconds).ToLocalTime() };
        //    }
        //}
    }
}
