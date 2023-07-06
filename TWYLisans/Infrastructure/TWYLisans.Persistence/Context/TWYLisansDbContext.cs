using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities;

namespace TWYLisans.Persistence.Context
{
    public class TWYLisansDbContext:DbContext
    {
        public TWYLisansDbContext(DbContextOptions options):base(options)
        {   }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Licence> Licences{ get; set; }
    }
}
