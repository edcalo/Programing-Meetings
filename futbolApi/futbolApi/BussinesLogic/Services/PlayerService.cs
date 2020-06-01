using FutbolApi.BussinesLogic.Interfaces;
using FutbolApi.Data.Dto;
using FutbolApi.Data.Models;
using FutbolApi.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutbolApi.BussinesLogic.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly ApplicationDbContext _dbContext;
        public PlayerService(ApplicationDbContext dbContext) => _dbContext = dbContext;
        public async Task<bool> Add(Player model)
        {
            await _dbContext.Players.AddAsync(model);
            return await CommitAsync();
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            var result = new List<Player>();
            //Include
            result = await _dbContext.Players.Include(x => x.Team).ToListAsync();
            //Lazy-loading
            result = await _dbContext.Players.ToListAsync();
            return result;
        }

        public async Task<Player> First()
        {
            var result = await _dbContext.Players.FirstOrDefaultAsync();
            //if (result != null)
            //{
            //    var theMagicOfLaziLoading = result.Team.Name;
            //}
            return result;
        }


        public async Task<IEnumerable<Player>> OptimizedQuery()
        {
            var result = new List<Player>();

            #region 1
            /**HACER ESTO cuando necesesitas que las consultas sean mas eficientes y cuando no vas a modificar dichos resultados**/
            result = await _dbContext.Players.AsNoTracking().ToListAsync();
            #endregion

            #region 2
            /**UTILIZA IQUERABLE CUANDO SEA NECESARIO para tus querys dinamicos**/

            /*IMPORTANTE PARA CREAR QUERYS DINAMICOS Y FILTROS DE DATOS DEPENDIENDO SI LLEGA UN VALOR O NO*/

            /*BUENA PRACTICA*/
            var test = _dbContext.Players.AsQueryable(); //ya la entidad es IQUERYABLE<PLAYERS>
            
            test = test.Where(x => x.Name.Contains("person"));
            
            test = test.Where(x => x.Name.Contains("1"));
           
            
            result = await test.ToListAsync();


            /*MALA PRACTICA*/
            var test2 = await _dbContext.Players.ToListAsync();
            result = test2.Where(x => x.Name.Contains("person")).ToList();
            #endregion

            #region 3 
            //BUENA PRACTICA 
            var test3 = await _dbContext.Players.FirstOrDefaultAsync(x => x.Name.Contains("1"));

            //MALA PRACTICA
            test3 = await _dbContext.Players.Where(x => x.Name.Contains("1")).FirstOrDefaultAsync();
            #endregion


            #region 4 
            //pagina tus elementos /**Este ejemplo es basado en que ya saben utilizar skip y take*/
            result = await _dbContext.Players.Where(x => x.Name.Contains("1")).Skip(1).Take(10).ToListAsync();
            #endregion

            #region 5 
            /// implementa el metodo 
            CommitAsync() //=> para que tus transaciones errones puedan hacer rollback
            #endregion

            #region 6 
            ///PROYECTA LOS ELEMENTOS NO RETORNES TODO
            var test6 = await _dbContext.Players.Select(x => new PlayerDTO { Name = x.Name }).ToListAsync();
            #endregion

            #region 7 
            /*SI VAS A CONTAR ELEMENTOS HAZ ESTO*/
            var counts = await _dbContext.Players.CountAsync(x => x.Name.Contains("1"));
            /*Y NO ESTO*/
            var countsv2 = await _dbContext.Players.Where(x => x.Name.Contains("1")).CountAsync();
            #endregion

            /*UTILIZA IENUMERABLE CUANDO VAS A RECORRER DATOS Y
             * IQUERABLE CUANDO VAS A FILTRAR EN DATOS 
             * Y GENERAR CONSULTAS DINAMICAS 🐱🔥🔥🔥🔥*/
            return result;
        }



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
