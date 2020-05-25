using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Repository.Interface
{
    public interface IRepository<TContext,TEntity> where TContext : DbContext where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<bool> Add(TEntity model);
        Task<TEntity> Get(Guid id);
    }
}
