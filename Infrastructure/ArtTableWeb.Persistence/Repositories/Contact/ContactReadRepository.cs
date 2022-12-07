using ArtTableWeb.Application.Repositories;
using ArtTableWeb.Domain.Entities;
using ArtTableWeb.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Persistence.Repositories
{
    public class ContactReadRepository : ReadRepository<Contact>, IContactReadRepository
    {
        public ContactReadRepository(ArtTableWebDbContext context) : base(context)
        {
        }
    }
}
