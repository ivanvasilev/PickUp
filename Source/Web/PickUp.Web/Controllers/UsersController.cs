namespace PickUp.Web.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Users;

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
