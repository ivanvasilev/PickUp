using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickUp.Web.ViewModels.TripsList
{
    public class TripsListViewModel
    {
        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public IEnumerable<PageableTripViewModel> Trips { get; set; }
    }
}