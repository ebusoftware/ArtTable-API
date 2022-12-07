using ArtTableWeb.Domain.Entities;
using ArtTableWeb.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ArtTableWebDbContext>
    {
        public ArtTableWebDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ArtTableWebDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
