using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomaApp.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace DiplomaApp.Repositories.Interfaces
{
    public interface IUserUnitOfWork:IDisposable
    {
        UserManager<User> UserManager { get; }

        SignInManager<User> SignInManager { get; }

        RoleManager<IdentityRole> RoleManager { get; }

        void Save();
    }
}
