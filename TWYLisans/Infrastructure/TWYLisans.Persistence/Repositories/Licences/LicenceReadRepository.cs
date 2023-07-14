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
    }
}
