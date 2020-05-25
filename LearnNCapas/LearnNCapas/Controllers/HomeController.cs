using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LearnNCapas.Models;
using BussinesLayer.UoW;
using Microsoft.AspNetCore.Identity;

namespace LearnNCapas.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _services;

        public HomeController(IUnitOfWork services) => _services = services;

        public async Task<IActionResult> Index()
        {
            
            //for add seedd data
            //var seedData = new IdentityUser
            //{
            //    UserName = "test@gmail.com",
            //    Email = "test@gmail.com",
            //    NormalizedUserName = "test".ToUpper()
            //};

            //var resul = await _services.UserService.Add(seedData);

            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            var result = await _services.UserService.GetAll();
            return View();
        }

    }
}
