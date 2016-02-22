namespace PickUp.Web.ViewModels.TripsList
{
    using System.Collections.Generic;

    public class TripsListViewModel
    {
        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public IEnumerable<PageableTripViewModel> Trips { get; set; }
    }
}
