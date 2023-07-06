using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Persistence.Context;

namespace TWYLisans.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TWYLisansDbContext>
    {
        //Entity Frasamwork  dbcontext dotnet ekleme çözümü
        public TWYLisansDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<TWYLisansDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString,null);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
