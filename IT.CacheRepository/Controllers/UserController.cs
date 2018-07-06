using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using IT.CacheRepository.Models;


namespace IT.CacheRepository.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly IDistributedCache _userCache;

        public UserController(IDistributedCache distributedCache) => _userCache = distributedCache;

        // GET api/values
        [HttpGet]
        public async Task<User> GetOrders(string name)
        {
            User user = new User();

            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    // get user from redis cache
                    user = await RedisCache.GetObjectAsync<User>(_userCache, name);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public async Task<User> GetUser(string name)
        {
            User user = new User();

            try
            {
                    // get user from redis cache
                    user = await RedisCache.GetObjectAsync<User>(_userCache, name);

              
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
