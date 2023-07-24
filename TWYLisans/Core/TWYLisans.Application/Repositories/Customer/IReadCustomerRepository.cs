using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities;

namespace TWYLisans.Application.Repositories
{
    public interface IReadCustomerRepository:IReadRepository<Customer>
    {
        Task<Customer> GetByIdCustomerAsync(int id);

    }
}
