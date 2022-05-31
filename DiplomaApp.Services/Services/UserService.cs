using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiplomaApp.Data.Data;
using DiplomaApp.Data.Models;
using DiplomaApp.Repositories.Interfaces;
using DiplomaApp.Repositories.Models;
using DiplomaApp.Services.Interfaces;
using DiplomaApp.Services.Models;
using Microsoft.AspNetCore.Identity;

namespace DiplomaApp.Services.Services
{
    public class UserService:IUserService
    {
        private readonly IUserUnitOfWork userUnitOfWork;
        private readonly IMapper mapper;
        private readonly IRoleService roleService;
        private ICollection<string> errorsCollection;

        public UserService(IdentityContext context, IMapper mapper, IRoleService roleService,
                             UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.mapper = mapper;
            this.roleService = roleService;
            userUnitOfWork = new UserUnitOfWork(context, userManager, signInManager);
        }

        public ICollection<string> ErrorsCollection => errorsCollection;

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = userUnitOfWork.UserManager.Users.ToList();
            var userDto = new UserDto();
            List<UserDto> usersDto = new List<UserDto>();
            IList<string> userRoles;
            foreach (var user in users)
            {
                userRoles = await userUnitOfWork.UserManager.GetRolesAsync(user);
                userDto = mapper.Map<UserDto>(user);
                userDto.RoleNames = userRoles;
                usersDto.Add(userDto);
            }

            return usersDto;
        }

        public async Task<bool> IsUserCreated(UserDto userDto, string password)
            //Todo: on result succeeded use Ivolunteer/Irefugee service to add 
        {
            bool isCreated = false;
            var user = mapper.Map<User>(userDto);
            var result = await userUnitOfWork.UserManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await userUnitOfWork.SignInManager.SignInAsync(user, false);
                IdentityRole addedRole = await roleService.FindByName(userDto.RoleName);
                await userUnitOfWork.UserManager.AddToRoleAsync(user, addedRole.Name);
                isCreated = true;
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    errorsCollection = new List<string>();
                    errorsCollection.Add(error.Description);
                }
            }

            return isCreated;
        }

        public async Task<bool> IsUserExist(UserDto userDto)
        {
            bool isExisted = false;
            User signedUser = await userUnitOfWork.UserManager.FindByEmailAsync(userDto.Email);
            var result = await userUnitOfWork.SignInManager.PasswordSignInAsync(signedUser.UserName, userDto.Password, true, false);
            if (result.Succeeded)
            {
                isExisted = true;
            }

            return isExisted;
        }

        public async Task<bool> IsUserAdmin(UserDto userDto)
        {
            bool isAdmin = false;
            User signedUser = await userUnitOfWork.UserManager.FindByEmailAsync(userDto.Email);
            var userRoles = await userUnitOfWork.UserManager.GetRolesAsync(signedUser);
            if (userRoles.Contains("admin"))
            {
                isAdmin = true;
            }

            return isAdmin;
        }

        public async Task UserLogOut()
        {
            await userUnitOfWork.SignInManager.SignOutAsync();
        }

        public async Task<UserDto> FindUserByIdAsync(string id)
        {
            User user = await userUnitOfWork.UserManager.FindByIdAsync(id);
            return mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> DeleteAsync(string id)
        {
            User user = await userUnitOfWork.UserManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await userUnitOfWork.UserManager.DeleteAsync(user);
            }
            return mapper.Map<UserDto>(user);
        }
    }
}
