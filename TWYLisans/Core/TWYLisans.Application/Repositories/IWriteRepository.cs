using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Domain.Entities.Common;

namespace TWYLisans.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddAsync(List<T> entity);
        bool Remove(T entity);
        Task<bool> RemoveAsync(int id);
        bool Update(T entity);
        Task<int> SaveAsync();
    }
}
