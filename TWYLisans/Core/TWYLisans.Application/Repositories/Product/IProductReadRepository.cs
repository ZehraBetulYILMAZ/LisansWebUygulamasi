using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities;

namespace TWYLisans.Application.Repositories
{
    public interface IProductReadRepository:IReadRepository<Product>
    {
        Task<Product> GetByIdProductAsync(int id);
    }
}
