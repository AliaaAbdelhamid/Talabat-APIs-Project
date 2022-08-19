using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.BLL.Repositories;
using Talabat.BLL.Specifications;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Interfaces
{
    public interface IGenaricRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdWithSpecifitionAsync(ISpecifications<T> specification);
        Task<IReadOnlyList<T>> GetAllWithSpecifitionAsync(ISpecifications<T> specification);
        Task<int> GetCountAsync(ISpecifications<T> specification);
    }
} 
