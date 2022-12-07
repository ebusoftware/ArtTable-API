using ArtTableWeb.Application.Repositories;
using ArtTableWeb.Application.Repositories.File;
using ArtTableWeb.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Persistence.Repositories
{
    public class FileWriteRepository : WriteRepository<Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(ArtTableWebDbContext context) : base(context)
        {
        }
    }
}
