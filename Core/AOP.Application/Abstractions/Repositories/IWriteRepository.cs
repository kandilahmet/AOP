using AOP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Application.Abstractions.Repositories
{
    public interface IWriteRepository<T>: IBaseRepository<T>
        where T : BaseEntity
    {
        public Task<bool> AddAsync(T Entity);
        public Task AddRangeAsync(List<T> Entities);
        public void UpdateRange(List<T> Entities);
        public void RemoveRange(List<T> Entities);
        public Task<bool> SaveAsync(); 
    }
}
