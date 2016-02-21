using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PickUp.Data.Models;
using PickUp.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickUp.Services.Data
{
    public class UsersService : IUsersService
    {
        public UsersService(DbContext context)
        {
            this.Context = context;
        }

        private DbContext Context { get; }

        public ApplicationUser GetUserById(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.Context));
            var user = userManager.FindById(id);
            return user;
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.Context));
            var users = userManager.Users;

            return users;
        }
    }
}
