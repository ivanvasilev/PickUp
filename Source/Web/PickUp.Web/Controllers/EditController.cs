﻿namespace PickUp.Web.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using PickUp.Services.Data.Contracts;
    using PickUp.Web.ViewModels.Users;

    public class EditController : BaseController
    {
        private IUsersService users;

        public EditController(IUsersService users)
        {
            this.users = users;
        }

        [HttpPost]
        public ActionResult EditProfile(UserDetailsViewModel user)
        {
            var userId = this.User.Identity.GetUserId();
            var userToUpdate = this.users.GetById(userId);
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.UserName = user.UserName;
            userToUpdate.Age = user.Age;
            this.users.Update(userToUpdate);

            return this.Redirect("/Users/Details");
        }
    }
}
