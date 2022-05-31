using AutoMapper;
using MetricsProject_ver1.DAL.Models;
using MetricsProject_ver1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricDTO>();
            CreateMap<DotNetMetric, DotNetMetricDTO>();
            CreateMap<HddMetric, HddMetricDTO>();
            CreateMap<NetWorkMetric, NetWorkMetricDTO>();
            CreateMap<RamMetric, RamMetricDTO>();

        }
    }
}
