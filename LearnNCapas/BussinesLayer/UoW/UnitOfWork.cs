using BussinesLayer.Services;
using LearnNCapas.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private UserService _userService;
        public UnitOfWork(ApplicationDbContext dbContext) => _dbContext = dbContext;
        public IUserService UserService => _userService ?? (_userService = new UserService(_dbContext));
    }
}
