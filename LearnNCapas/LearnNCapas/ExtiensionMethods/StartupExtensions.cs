using BussinesLayer.UoW;
using LearnNCapas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnNCapas.ExtiensionMethods
{
    public static class  StartupExtensions
    {
        public static void DbContextImplementations(this IServiceCollection services , IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        public static void ServicesImplementations(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
