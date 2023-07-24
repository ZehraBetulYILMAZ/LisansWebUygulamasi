using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Application.Repositories;
using TWYLisans.Domain.Entities.Common;
using TWYLisans.Persistence.Context;

namespace TWYLisans.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly TWYLisansDbContext _context;
        public WriteRepository(TWYLisansDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entry = await Table.AddAsync(entity);
            return entry.State == EntityState.Added;
        }

        public async Task<bool> AddAsync(List<T> entity)
        {
            await Table.AddRangeAsync(entity);
            return true;
        }
       public bool Update(T entity)
        {
            EntityEntry<T> entry = Table.Update(entity);
            return entry.State == EntityState.Modified;
        }
        public Task<int> SaveAsync()
         =>_context.SaveChangesAsync();

      
    }
}
