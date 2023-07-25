using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities;

namespace TWYLisans.Persistence.Context
{
    public class TWYLisansDbContext : DbContext
    {
        public TWYLisansDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Licence> Licences { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Town> Towns { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
            new City { ID = 1 , cityname="Ankara" },
            new City { ID = 2, cityname = "Bursa" });
            modelBuilder.Entity<Town>().HasData(
                new Town { ID = 1, cityId = 1, townname = "Çankaya" },
                new Town { ID = 2, cityId = 1, townname = "Haymana" },
                new Town { ID = 3, cityId = 2, townname = "Nilüfer" });
            modelBuilder.Entity<Category>().HasData(
               new Category { ID = 1, categoryName="A kategorisi" },
               new Category { ID = 2, categoryName="B kategorisi" });
            modelBuilder.Entity<Product>().HasData(
              new Product { ID = 1, productName = "A Ürünü" , active = true, productDescription="A açıklaması",categoryId=1},
               new Product { ID = 2, productName = "B Ürünü", active = true, productDescription = "B açıklaması", categoryId = 2 }
             );
            modelBuilder.Entity<Customer>().HasData(
            new Customer { ID = 1, companyName = "A şirketi", active = true, ePosta="aaa@aaa.aaa", mailaddress = Encoding.ASCII.GetBytes("mailadress1"),phoneNumber="00220202101",townId=1 },
             new Customer { ID = 2, companyName = "B şirketi", active = true, ePosta = "bbb@bbb.bbb", mailaddress = Encoding.ASCII.GetBytes("mailadress2"), phoneNumber = "22202020202", townId = 2 },
             new Customer { ID = 3, companyName = "C şirketi", active = true, ePosta = "ccc@ccc.ccc", mailaddress = Encoding.ASCII.GetBytes("mailadress3"), phoneNumber = "30303030303", townId = 3 } 
           );
            modelBuilder.Entity<Licence>().HasData(
            new Licence { ID = 1, licencekey = Guid.NewGuid(), active = true, creationDate = DateTime.Now, endingDate = DateTime.Now, customerId = 1, productId = 1 },
            new Licence { ID = 2, licencekey = Guid.NewGuid(), active = true, creationDate = DateTime.Now, endingDate = DateTime.Now, customerId = 2, productId = 2 },
            new Licence { ID = 3, licencekey = Guid.NewGuid(), active = true, creationDate = DateTime.Now, endingDate = DateTime.Now, customerId = 2, productId = 1 },
            new Licence { ID = 4, licencekey = Guid.NewGuid(), active = true, creationDate = DateTime.Now, endingDate = DateTime.Now, customerId = 3, productId = 2 });
        }
    }
}
