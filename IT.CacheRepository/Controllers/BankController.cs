using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using IT.CacheRepository.Models;

namespace IT.CacheRepository.Controllers
{
    // an example showing how the RedisCache class can be used with other object type
    [Route("api/[controller]")]
    public class BankController : Controller
    {
        private readonly IDistributedCache _Cache;

        public BankController(IDistributedCache distributedCache) => _Cache = distributedCache;

        // GET api/values
        [HttpGet("{id}")]
        public async Task<Bank> GetBankAccount(string id)
        {
            Bank bank = new Bank();

            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    bank = await RedisCache.GetObjectAsync<Bank>(_Cache, id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bank;
        }

        // POST api/values
        [HttpPost]
        public async Task<bool> Post([FromBody]Bank bank)
        {
            bool result = false;
            try
            {
                if (bank != null)
                {
                    await RedisCache.SetObjectAsync(_Cache, bank.BankAccountID.ToString(), bank);

                    result = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}