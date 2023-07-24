using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Application.Repositories;
using TWYLisans.Domain.Entities;
using TWYLisans.Persistence.Context;

namespace TWYLisans.Persistence.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, IReadCustomerRepository
    {
        public CustomerReadRepository(TWYLisansDbContext context) : base(context)
        {
        }

        public async Task<Customer> GetByIdCustomerAsync(int id)
        {
            return await Table
                .Include(c => c.town)
                .Include(t => t.town.city)
                .Include(l=> l.licences)
                .ThenInclude(P=>P.product)
                .FirstOrDefaultAsync(c => c.ID == id);
        }

    }
}
