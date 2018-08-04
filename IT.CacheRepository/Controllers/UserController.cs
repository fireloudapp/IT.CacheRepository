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
        public async Task<User> GetUsers(string name)
        {
            User user = new User();

            try
            {

                if (!string.IsNullOrEmpty(name))
                {
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
                if (!string.IsNullOrEmpty(name))
                {
                    user = await RedisCache.GetObjectAsync<User>(_userCache, name);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }

        // POST api/values
        [HttpPost]
        public async Task<bool> Post([FromBody]User user)
        {
            bool result = false;
            try
            {
                if (user != null)
                {
                    await RedisCache.SetObjectAsync(_userCache, user.UserName, user);

                    result = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
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
