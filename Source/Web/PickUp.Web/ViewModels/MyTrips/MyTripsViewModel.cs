using PickUp.Data.Models;
using PickUp.Web.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickUp.Web.ViewModels.MyTrips
{
    public class MyTripsViewModel
    {
        public IEnumerable<Trip> AttendedTrips { get; set; }

        public IEnumerable<Trip> CreatedTrips { get; set; }
    }
}