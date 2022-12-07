using ArtTableWeb.Application.Repositories;
using ArtTableWeb.Domain.Entities.Common;
using ArtTableWeb.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ArtTableWebDbContext _context;

        public ReadRepository(ArtTableWebDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>(); //gerekli enetity'i almak için Set methodunu kullandık. 

        public IQueryable<T> GetAll() //Bütün kayıtları getir
            => Table;

        public async Task<T> GetByIdAsync(string id)
            => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        => await Table.FirstOrDefaultAsync(method);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        => Table.Where(method);
    }
}
