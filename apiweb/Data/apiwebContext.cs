using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apiweb;

namespace apiweb.Data
{
    public class apiwebContext : DbContext
    {
        public apiwebContext (DbContextOptions<apiwebContext> options)
            : base(options)
        {
        }

        public DbSet<apiweb.Customer> Customer { get; set; }
        public DbSet<apiweb.Customer> GetCustomerData { get; }
        public DbSet<apiweb.Customer> GetAllCustomers { get; }
    }
}
