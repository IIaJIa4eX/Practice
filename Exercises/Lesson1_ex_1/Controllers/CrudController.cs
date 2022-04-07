using Lesson1_ex_1_API_micro.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson1_ex_1_API_micro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //toreview
    public class CrudController : ControllerBase
    {
        private readonly ValuesHolder _holder;
        public CrudController(ValuesHolder holder)
        {
            _holder = holder;
        }
        [HttpPost("create")]
        public IActionResult Create([FromQuery] string date, [FromQuery]string temperature)
        {
            if(!_holder.Add(date, temperature))
            {
                return Ok("Not Added");
            }
            return Ok("Added");
        }
        [HttpGet("read")]
        public IActionResult Read()
        {
            return Ok(_holder.Get());
        }

        [HttpGet("rangebymin")]
        public IActionResult GetRangeByMinutes([FromQuery] string fromDate, string toDate)
        {
            return Ok(_holder.GetRangeByMinutes(fromDate,toDate));
        }

        [HttpGet("rangebydays")]
        public IActionResult GetRangeByDays([FromQuery] string fromDate, string toDate)
        {
            return Ok(_holder.GetRangeByDays(fromDate, toDate));
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] string stringsToUpdate,
        [FromQuery] string newValue)
        {
            if (!_holder.Update(stringsToUpdate, newValue))
            {
                return Ok("Not Updated");
            }
            return Ok("Updated");
        }
        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] string stringToDelete)
        {
            if (_holder.Delete(stringToDelete))
            {
                return Ok("Deleted");
            }

            return Ok("Not Deleted");
        }
    }
}
    
