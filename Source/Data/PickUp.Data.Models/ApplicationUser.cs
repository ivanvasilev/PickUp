namespace PickUp.Data.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Rate> rates;
        private ICollection<Trip> trips;
        private ICollection<Vehicle> vehicles;

        public ApplicationUser()
        {
            this.rates = new HashSet<Rate>();
            this.trips = new HashSet<Trip>();
            this.vehicles = new HashSet<Vehicle>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<Rate> Rates
        {
            get { return this.rates; }
            set { this.rates = value; }
        }

        public virtual ICollection<Trip> Trips
        {
            get { return this.trips; }
            set { this.trips = value; }
        }

        public virtual ICollection<Vehicle> Vehicles
        {
            get { return this.vehicles; }
            set { this.vehicles = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
