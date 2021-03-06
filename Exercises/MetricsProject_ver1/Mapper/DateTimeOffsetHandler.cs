using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.Mapper
{
    public class DateTimeOffsetHandler : SqlMapper.TypeHandler<DateTimeOffset>
    {
        public override DateTimeOffset Parse(object value) => DateTimeOffset.FromUnixTimeSeconds((long)value).ToLocalTime();
        public override void SetValue(IDbDataParameter parameter, DateTimeOffset value) => parameter.Value = value;

    }
}
