using BussinesLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.UoW
{
    public interface IUnitOfWork
    {
        public IUserService UserService { get; }
    }
}
