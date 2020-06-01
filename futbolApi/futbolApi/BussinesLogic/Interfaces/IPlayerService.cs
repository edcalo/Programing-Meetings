using FutbolApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutbolApi.BussinesLogic.Interfaces
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetAll();
        Task<bool> Add(Player model);
        Task<bool> CommitAsync();
        Task<Player> First();
        Task<IEnumerable<Player>> OptimizedQuery();
    }
}
