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

        public ApplicationUser GetById(string id)
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

        public void Update(ApplicationUser user)
        {
            var store = new UserStore<ApplicationUser>(this.Context);
            var userManager = new UserManager<ApplicationUser>(store);
            var context = store.Context;
            userManager.Update(user);
            context.SaveChanges();
        }

        public void Create(ApplicationUser user, string password)
        {
            var userStore = new UserStore<ApplicationUser>(this.Context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.Create(user, password);
            var context = userStore.Context;
            context.SaveChanges();
        }

        public void Delete(ApplicationUser user)
        {
            var userStore = new UserStore<ApplicationUser>(this.Context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.Delete(user);
            var context = userStore.Context;
            context.SaveChanges();
        }
    }
}
