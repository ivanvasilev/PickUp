namespace PickUp.Web.ViewModels.Home
{
    using Users;
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<TripViewModel> Trips { get; set; }

        public IEnumerable<DriverViewModel> TopDrivers { get; set; }

        public IEnumerable<PassengerViewModel> TopPassengers { get; set; }
    }
}
