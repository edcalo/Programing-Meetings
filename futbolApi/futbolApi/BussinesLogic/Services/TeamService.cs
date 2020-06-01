using FutbolApi.BussinesLogic.Interfaces;
using FutbolApi.Data.Models;
using FutbolApi.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutbolApi.BussinesLogic.Services
{
    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext _dbContext;
        public TeamService(ApplicationDbContext dbContext) => _dbContext = dbContext;
        public async Task<bool> Add(Team model)
        {
            await _dbContext.Teams.AddAsync(model);
            return await CommitAsync();
        }

        public async Task<IEnumerable<Team>> GetAll() => await _dbContext.Teams.ToListAsync();
        public async Task<bool> CommitAsync()
        {
            var result = true;
            using var transaction = _dbContext.Database.BeginTransaction();
            {
                try
                {
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    result = false;
                    await transaction.RollbackAsync();
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
            return result;
        }
    }
}
