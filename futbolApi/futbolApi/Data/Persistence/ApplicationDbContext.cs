using FutbolApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutbolApi.Data.Persistence
{
    public class ApplicationDbContext : DbContext
    {

        public static readonly ILoggerFactory Factory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        //only dev


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
             => optionsBuilder
               .UseLoggerFactory(Factory)
              .UseSqlServer(@"Server=DESKTOP-PRGFMF7\SQLEXPRESS;Database=TeamsDb;Trusted_Connection=True;MultipleActiveResultSets=true");


        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
