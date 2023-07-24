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

namespace TWYLisans.Persistence.Repositories.Licences
{
    public class LicenceWriteRepository : WriteRepository<Licence>, ILicenceWriteRepository
    {
        public LicenceWriteRepository(TWYLisansDbContext context) : base(context)
        {
        }

        public bool RemoveLicence(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLicence (Licence entity)
        {
            var licence = Table.Find(entity.ID);
            if (licence != null)
            {
                licence.licencekey = entity.licencekey;
                licence.endingDate = entity.endingDate;
                EntityEntry<Licence> entry = Table.Update(licence);
                return entry.State == EntityState.Modified;
            }
            return false;
        }
    }
}
