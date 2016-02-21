using Microsoft.AspNet.Identity;
using PickUp.Services.Data.Contracts;
using PickUp.Web.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickUp.Web.Controllers
{
    public class UsersController : BaseController
    {
        private IUsersService users;

        public UsersController(IUsersService users)
        {
            this.users = users;
        }

        public ActionResult Details()
        {
            var userId = this.User.Identity.GetUserId();
            var userToShow = this.Mapper.Map<UserDetailsViewModel>(this.users
                .GetById(userId));

            return this.View(userToShow);
        }
    }
}