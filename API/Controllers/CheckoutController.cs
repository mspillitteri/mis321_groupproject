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
    public class CheckoutController : ControllerBase
    {
        // GET: api/Checkout
        [HttpGet]
        public IEnumerable<string> GetAllCheckouts()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Checkout/5
        [HttpGet("{id}", Name = "GetCheckout")]
        public string GetCheckout(int id)
        {
            return "value";
        }

        // POST: api/Checkout
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Checkout/5
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
