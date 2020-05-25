using BussinesLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Repository.Services
{
    public class BaseService<TContext, TEntity> : IRepository<TContext, TEntity> where TContext : DbContext where TEntity : class
    {
        private readonly TContext _dbContext;
        public BaseService(TContext context) => _dbContext = context;
        public virtual async Task<bool> Add(TEntity model)
        {
            _dbContext.Set<TEntity>().Add(model);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public virtual async Task<TEntity> Get(Guid id) => await _dbContext.Set<TEntity>().FindAsync(id);

        public virtual async Task<IEnumerable<TEntity>> GetAll() => await _dbContext.Set<TEntity>().ToListAsync();
    }
}
