using FutbolApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutbolApi.BussinesLogic.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAll();
        Task<bool> Add(Team model);
        Task<bool> CommitAsync();
    }
}
