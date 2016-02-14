namespace PickUp.Data.Models
{
    using PickUp.Data.Common.Models;

    public class Vehicle : BaseModel<int>
    {
        public string RegistrationNumber { get; set; }

        public int? Year { get; set; }

        public string Color { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string DriverId { get; set; }

        public virtual ApplicationUser Driver { get; set; }
    }
}
