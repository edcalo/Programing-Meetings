using BussinesLayer.Repository.Interface;
using BussinesLayer.Repository.Services;
using LearnNCapas.Data;
using LearnNCapas.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    //only example write in one separated file
    public interface IUserService : IRepository<ApplicationDbContext,IdentityUser>
    {
        bool YesNo();
    }

    //only example write in one separated file 
    public static class DateTimeExtension
    {
        public static string ToStrDateTime(this DateTime date) => date.ToShortDateString();
        
    }

    public class UserService : BaseService<ApplicationDbContext, IdentityUser>, IUserService
    {
        private readonly ApplicationDbContext _db;
        public UserService(ApplicationDbContext context) : base(context)
        {
            _db = context;
        }

        public override async Task<IEnumerable<IdentityUser>> GetAll()
        {
            var model = await base.GetAll();
            model = model.Where(x => x.Email.Contains("@gmail.com"));
            var strDate = DateTime.Now.ToStrDateTime();
            return model;
        }


        public bool YesNo()
        {
            return true;
        }
    }
}
