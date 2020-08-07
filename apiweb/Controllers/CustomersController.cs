using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiWeb.Data;
using Microsoft.AspNetCore.Authorization;
using ApiWeb.Models;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using Newtonsoft.Json;

namespace ApiWeb.Controllers
{
    [Authorize]
    [Route("Api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApiWebContext _context;
        private readonly IDistributedCache _distributedCache;
        private readonly string CACHEKEY = "customerslist";
        public CustomersController(ApiWebContext context, IDistributedCache distributedCache)
        {
            _context = context;
            _distributedCache = distributedCache;
        }

        // GET: api/Customers/GetAllCustomers 
        [HttpGet("GetAllCustomers")]
        public async Task<IEnumerable<Customer>> GetCustomer()
        {
            string customersList = await _distributedCache.GetStringAsync(CACHEKEY);
            if (customersList == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<IEnumerable<Customer>>(customersList);
        }

        // GET: api/Customers/GetCustomerData/5
        [HttpGet("GetCustomerData/{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customersList = JsonConvert.DeserializeObject<IEnumerable<Customer>>(await _distributedCache.GetStringAsync(CACHEKEY));
            if (customersList == null)
            {
                return NotFound();
            }
            Customer customer = new Customer();
            foreach (Customer c in customersList)
            {
                if (c.CustomerId.Equals(id))
                    customer = c;
            }
            return customer;
        }

        // POST: api/Customers/CreateCustomer
        [HttpPost("CreateCustomer")]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            var response = CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
            CacheUpdate();
            return response;
        }

        public async void CacheUpdate()
        {
            //Metodo que almacena los datos en Redis Cache
            var customerList = await _context.Customer.ToListAsync();
            var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(60))
                .SetAbsoluteExpiration(DateTime.Now.AddHours(6));
            await _distributedCache.SetStringAsync(CACHEKEY, JsonConvert.SerializeObject(customerList), options);
        }
    }
}
