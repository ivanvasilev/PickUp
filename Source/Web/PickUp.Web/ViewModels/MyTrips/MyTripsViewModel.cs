namespace PickUp.Web.ViewModels.MyTrips
{
    using System.Collections.Generic;
    using PickUp.Data.Models;

    public class MyTripsViewModel
    {
        public IEnumerable<Trip> AttendedTrips { get; set; }

        public IEnumerable<Trip> CreatedTrips { get; set; }
    }
}
