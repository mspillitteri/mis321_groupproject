using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Models.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/User
        [EnableCors("Policy")]
        [HttpGet]
        public List<User> Get()
        {
            IGetAllUsers getAllUsers = new ReadUserData();
            return getAllUsers.GetAllUsers();
        }

        // GET: api/User/5
        [EnableCors("Policy")]
        [HttpGet("{id}", Name = "GetUser")]
        public User GetUser(int id)
        {
            IGetUser getUser = new ReadUserData();
            return getUser.GetAUser(id);
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
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
