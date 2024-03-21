using AOP.Application.Abstractions.Repositories;
using AOP.Domain.Entities;
using AOP.Persistence.EFCore.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Persistence.EFCore
{
    public class EFCoreReadRepository<T> : EFCoreBaseRepository<T,DbContext>, IReadRepository<T>
        where T:BaseEntity
    {
        public EFCoreReadRepository(MsSqlDbContext msSqlDbContext):base(msSqlDbContext)
        {
            
        }
        public async IAsyncEnumerable<T> GetAll()
        {
            var queryable = Table;

            foreach (var item in await queryable.ToListAsync())
            {
                yield return item;
            }
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression)
        {
           return await Table.Where(expression).FirstOrDefaultAsync();
        }

        public async IAsyncEnumerable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            var queryable = Table.Where(expression);

            foreach (var item in await queryable.ToListAsync())
            {
                yield return item;
            }
        }
    }
}
