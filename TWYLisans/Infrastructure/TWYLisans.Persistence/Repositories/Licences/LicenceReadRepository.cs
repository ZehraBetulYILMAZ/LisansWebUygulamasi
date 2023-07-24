using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Application.Repositories;
using TWYLisans.Domain.Entities;
using TWYLisans.Persistence.Context;

namespace TWYLisans.Persistence.Repositories.Licences
{
    public class LicenceReadRepository : ReadRepository<Licence>, ILicenceReadRepository
    {
        public LicenceReadRepository(TWYLisansDbContext context) : base(context)
        {
        }

        public async Task<Licence> GetByIdLicenceAsync(int id)
        {
            return await Table
                .Include(e => e.customer)
                .Include(e => e.product)
                .FirstOrDefaultAsync(c => c.ID == id); 
        }
    }
}
