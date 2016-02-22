namespace PickUp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using PickUp.Data.Common.Models;

    public class Trip : BaseModel<int>
    {
        public DateTime StartDate { get; set; }

        public string Description { get; set; }

        public int AvailableSeats { get; set; }

        public int FromId { get; set; }

        [ForeignKey("FromId")]
        public virtual Location From { get; set; }

        public int ToId { get; set; }

        [ForeignKey("ToId")]
        public virtual Location To { get; set; }

        public string DriverId { get; set; }

        public virtual ApplicationUser Driver { get; set; }

        public virtual ICollection<ApplicationUser> Passengers { get; set; }
    }
}
