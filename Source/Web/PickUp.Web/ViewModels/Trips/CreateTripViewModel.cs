namespace PickUp.Web.ViewModels.Trips
{
    using PickUp.Data.Models;
    using PickUp.Web.Infrastructure.Mapping;
    using System;

    public class CreateTripViewModel : IMapFrom<Trip>
    {
        public DateTime StartDate { get; set; }

        public string Description { get; set; }

        public int AvailableSeats { get; set; }

        public int From { get; set; }

        public int To { get; set; }
    }
}