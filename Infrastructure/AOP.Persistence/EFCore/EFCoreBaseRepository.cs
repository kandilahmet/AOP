using AOP.Application.Abstractions.Repositories;
using AOP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Persistence.EFCore
{
    public class EFCoreBaseRepository<T,TContext> : IBaseRepository<T>
        where T : BaseEntity
        where TContext :DbContext

    {
        protected readonly TContext _context;
        public EFCoreBaseRepository(TContext context)
        {
            _context = context; 
        }
        public DbSet<T> Table { get => _context.Set<T>(); }
    }
}
