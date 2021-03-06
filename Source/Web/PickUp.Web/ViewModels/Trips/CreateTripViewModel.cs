﻿namespace PickUp.Web.ViewModels.Trips
{
    using System;
    using System.Web.Mvc;
    using PickUp.Data.Models;
    using PickUp.Web.Infrastructure.Mapping;

    public class CreateTripViewModel : IMapFrom<Trip>
    {
        public DateTime StartDate { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public int AvailableSeats { get; set; }

        public int From { get; set; }

        public int To { get; set; }
    }
}
