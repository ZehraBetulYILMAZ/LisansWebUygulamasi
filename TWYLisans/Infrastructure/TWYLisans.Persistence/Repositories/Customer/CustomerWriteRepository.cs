using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Application.Repositories;
using TWYLisans.Domain.Entities;
using TWYLisans.Persistence.Context;

namespace TWYLisans.Persistence.Repositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, IWriteCustomerRepository
    {
        TWYLisansDbContext context;
        public CustomerWriteRepository(TWYLisansDbContext context) : base(context)
        {
            this.context = context;
        }

        public bool RemoveCustomer(int id)
        {
            var entity = Table.Include(e=>e.licences).FirstOrDefault(c=> c.ID == id);
             if(entity != null) { 
               entity.active = false;
                if(entity.licences.Count> 0)
                {
                    foreach(var l in entity.licences)
                    {
                        l.active = false;
                    }
                }
               EntityEntry<Customer> entry = Table.Update(entity);
               return entry.State == EntityState.Modified;
            }
            return false;
        }

        public bool UpdateCustomer(Customer nCustomer)
        {
            var entity = Table.Include(e => e.town).Include(e=>e.town.city).FirstOrDefault(c => c.ID == nCustomer.ID);
            if (entity != null)
            {
                entity.companyName = nCustomer.companyName;
                entity.phoneNumber = nCustomer.phoneNumber;
                entity.ePosta = nCustomer.ePosta;
                context.Set<Town>().Remove(entity.town);
                context.Set<City>().Remove(entity.town.city);
                entity.town = nCustomer.town;
                entity.active=true;

                EntityEntry<Customer> entry = Table.Update(entity);
                return entry.State == EntityState.Modified;
            }
            return false;
        }
    }
}
