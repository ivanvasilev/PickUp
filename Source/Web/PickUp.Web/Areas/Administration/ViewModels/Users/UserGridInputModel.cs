namespace PickUp.Web.Areas.Administration.ViewModels
{
    using PickUp.Data.Models;
    using PickUp.Web.Infrastructure.Mapping;

    public class UserGridInputModel : IMapFrom<ApplicationUser>
    {
        public int Age { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Id { get; set; }
    }
}
