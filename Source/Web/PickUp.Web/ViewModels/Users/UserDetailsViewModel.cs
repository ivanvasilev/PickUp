namespace PickUp.Web.ViewModels.Users
{
    using System.Collections.Generic;
    using PickUp.Data.Models;
    using PickUp.Web.Infrastructure.Mapping;
    using PickUp.Web.ViewModels.Trips;

    public class UserDetailsViewModel : IMapFrom<ApplicationUser>
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        public IEnumerable<TripDetailsViewModel> Trips { get; set; }
    }
}
