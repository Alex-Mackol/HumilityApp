using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaApp.Services.Models
{
    public class UserDto
    {
        public UserDto()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { set; get; }
        public string RoleName { set; get; }
        public ICollection<string> RoleNames { set; get; }
        public string UserName { set; get; }

        public string Email { set; get; }

        public string Password { set; get; }
        public bool RememberMe { set; get; }
    }
}
