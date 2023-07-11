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
        public CustomerWriteRepository(TWYLisansDbContext context) : base(context)
        {
        }
    }
}
