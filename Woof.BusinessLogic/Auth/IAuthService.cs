using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Woof.DataAccess;
using Woof.Domain.Config;

namespace Woof.BusinessLogic.Auth
{
    public interface IAuthService
    {
        Task EnsureAdminExists();
    }

    internal class AuthService : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppSettings _appSettings;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly WoofDbContext _dbContext;
        public AuthService(RoleManager<IdentityRole> roleManager, AppSettings appSettings, UserManager<IdentityUser> userManager, WoofDbContext dbContext)
        {
            _roleManager = roleManager;
            _appSettings = appSettings;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public Task EnsureAdminExists()
        {
            throw new NotImplementedException();
        }
    }
}
