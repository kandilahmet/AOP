using AOP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Application.Abstractions.Repositories
{
    public interface IReadRepository<T>:IBaseRepository<T>
        where T:BaseEntity
    {
        public IAsyncEnumerable<T> GetAll();
        public IAsyncEnumerable<T> GetWhere(Expression<Func<T, bool>> expression);
        public Task<T> GetSingleAsync(Expression<Func<T, bool>> expression);
    }
}
