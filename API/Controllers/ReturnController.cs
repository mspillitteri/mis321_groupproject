using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnController : ControllerBase
    {
        // GET: api/Return
        [HttpGet]
        public IEnumerable<string> GetAllReturns()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Return/5
        [HttpGet("{id}", Name = "GetReturn")]
        public string GetReturn(int id)
        {
            return "value";
        }

        // POST: api/Return
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Return/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
