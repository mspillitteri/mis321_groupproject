using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Models.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        // GET: api/Item
        [EnableCors("Policy")]
        [HttpGet]
        public List<Item> Get()
        {
            IGetAllItems allItems = new ReadItemData();
            return allItems.GetAllItems();
        }

        // GET: api/Item/5
        [EnableCors("Policy")]
        [HttpGet("{id}", Name = "Get")]
        public Item Get(int itemid)
        {
            System.Console.WriteLine(itemid);
            IGetItem getItem = new ReadItemData();
            return getItem.GetAnItem(itemid);
        }

        // POST: api/Item
        [EnableCors("Policy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Item/5
        [EnableCors("Policy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("Policy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
