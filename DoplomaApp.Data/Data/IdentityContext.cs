using DiplomaApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaApp.Data.Data
{
    public class IdentityContext: IdentityDbContext<User>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
