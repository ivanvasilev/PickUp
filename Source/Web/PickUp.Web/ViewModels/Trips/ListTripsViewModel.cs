using PickUp.Data.Models;
using PickUp.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickUp.Web.ViewModels.Trips
{
    public class ListTripsViewModel : IMapFrom<Trip>
    {
        public int Id { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public DateTime StartDate { get; set; }

        public string Description { get; set; }

        public int AvailableSeats { get; set; }

        public string Driver { get; set; }
    }
}