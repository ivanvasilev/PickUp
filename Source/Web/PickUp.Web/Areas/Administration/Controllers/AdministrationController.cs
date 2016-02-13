namespace PickUp.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using PickUp.Common;
    using PickUp.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
