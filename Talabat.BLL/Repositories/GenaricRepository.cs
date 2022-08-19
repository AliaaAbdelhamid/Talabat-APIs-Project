using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.BLL.Interfaces;
using Talabat.BLL.Specifications;
using Talabat.DAL.Data;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Repositories
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : BaseEntity
    {
        public StoreContext Context { get; }
        public GenaricRepository(StoreContext context)
        {
            Context = context;
        }


        public async Task<IReadOnlyList<T>> GetAllAsync()
        => await Context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id)
        => await Context.Set<T>().FindAsync(id);

        private IQueryable<T> ApplySpecifications(ISpecifications<T> specification)
        {
            return SpecificationsEvalutor<T>.GetQuery(Context.Set<T>(), specification);


        }

        public async Task<T> GetByIdWithSpecifitionAsync(ISpecifications<T> specification)
        {
            return await ApplySpecifications(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecifitionAsync(ISpecifications<T> specification)
        {
            return await ApplySpecifications(specification).ToListAsync();
        }

        public async Task<int> GetCountAsync(ISpecifications<T> specification)
        => await ApplySpecifications(specification).CountAsync();
    }
}
