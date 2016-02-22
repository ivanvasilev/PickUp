namespace PickUp.Web.Areas.Administration.ViewModels.Trips
{
    using System;

    public class TripGridInputModel
    {
        public DateTime StartDate { get; set; }

        public string Description { get; set; }

        public int AvailableSeats { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public int Id { get; set; }
    }
}
