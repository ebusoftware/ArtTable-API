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
    public class BasketItemReadRepository : ReadRepository<BasketItem>, IBasketItemReadRepository
    {
        public BasketItemReadRepository(ArtTableWebDbContext context) : base(context)
        {
        }
    }
}
