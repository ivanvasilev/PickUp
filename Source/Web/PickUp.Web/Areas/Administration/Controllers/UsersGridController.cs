namespace PickUp.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using PickUp.Data.Models;
    using PickUp.Services.Data.Contracts;
    using PickUp.Web.Areas.Administration.ViewModels;
    using PickUp.Web.Infrastructure.Mapping;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class UsersGridController : Controller
    {
        private IUsersService users;

        public UsersGridController(IUsersService users)
        {
            this.users = users;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.users
                .GetAll()
                .To<UserGridViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Create([DataSourceRequest]DataSourceRequest request, UserGridInputModel user)
        {
            var newId = string.Empty;
            if (this.ModelState.IsValid)
            {
                var entity = new ApplicationUser
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age,
                    ImageId = 2
                };

                this.users.Create(entity, user.Password);
                newId = entity.Id;
            }

            var userToDisplay = this.users
                .GetAll()
                .To<UserGridViewModel>()
                .FirstOrDefault(x => x.Id == newId);

            return this.Json(new[] { userToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Update([DataSourceRequest]DataSourceRequest request, UserGridInputModel user)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.users.GetAll().FirstOrDefault(x => x.Id == user.Id);
                entity.FirstName = user.FirstName;
                entity.LastName = user.LastName;
                entity.Age = user.Age;
                this.users.Update(entity);
            }

            return this.Json(new[] { user }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest]DataSourceRequest request, ApplicationUser user)
        {
            var userToDelete = this.users.GetById(user.Id);
            this.users.Delete(userToDelete);

            return this.Json(new[] { user }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
