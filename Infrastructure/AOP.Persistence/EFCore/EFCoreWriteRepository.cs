using AOP.Application.Abstractions.Repositories;
using AOP.Domain.Entities;
using AOP.Persistence.EFCore.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Persistence.EFCore
{
    public class EFCoreWriteRepository<T> : EFCoreBaseRepository<T,DbContext>,IWriteRepository<T> where T : BaseEntity
    {
        public EFCoreWriteRepository(MsSqlDbContext msSqlDbContext):base(msSqlDbContext)
        {
            
        }
        public async Task<bool> AddAsync(T Entity)
        {
            if (Entity == null)
                throw new ArgumentNullException(nameof(Entity));

            EntityEntry<T> entityEntry = await Table.AddAsync(Entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task AddRangeAsync(List<T> Entities)
        {
            await Table.AddRangeAsync(Entities);
        }

        public void RemoveRange(List<T> Entities)
        {
            //if (!Entities.Any())
            //    throw new ArgumentNullException(nameof(Entities));

            Table.RemoveRange(Entities);//Entities boş oldugunda RemoveRange hata vermiyor fakat kontrol etmek iyidir.
        }

        public async Task<bool> SaveAsync()
        {
           return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateRange(List<T> Entities)
        {
            if (!Entities.Any())
                throw new ArgumentNullException(nameof(Entities));

            Table.UpdateRange(Entities);
        }
    }
}
