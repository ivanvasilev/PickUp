namespace PickUp.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.TripsList;
    using System.Collections.Generic;
    using Data.Models;

    public class TripsListController : Controller
    {
        private const int TripsPerPage = 10;
        private ITripsService trips;
        private ILocationsService locations;

        public TripsListController(ITripsService trips, ILocationsService locations)
        {
            this.trips = trips;
            this.locations = locations;
        }

        // GET: TripsList
        // , string from = null, string to = null, string datepicker = null
        public ActionResult Index(int page = 1, string from = "", string to = "", string datepicker = "")
        {
            var locations = new List<Location>();
            locations.Add(new Location
            {
                Id = 0,
                Name = string.Empty
            });

            locations.AddRange(this.locations.GetAll().ToList());
            this.ViewData["Locations"] = new SelectList(locations, "Name", "Name");
            
            var pagesToSkip = (page - 1) * TripsPerPage;
            var allTrips = this.trips.GetAll().Count();

            var tripsToShow = this.trips
                .GetAll()
                .To<PageableTripViewModel>()
                .ToList();

            if (!string.IsNullOrEmpty(from))
            {
                tripsToShow = tripsToShow.Where(x => x.From == from).ToList();
            }

            if (!string.IsNullOrEmpty(to))
            {
                tripsToShow = tripsToShow.Where(x => x.To == to).ToList();
            }

            if (!string.IsNullOrEmpty(datepicker))
            {
                var givenDate = DateTime.Parse(datepicker);
                tripsToShow = tripsToShow.Where(x => x.StartDate >= givenDate).ToList();
            }

            var totalpages = (int)Math.Ceiling(tripsToShow.Count / (decimal)TripsPerPage);
            tripsToShow = tripsToShow.Skip(pagesToSkip).Take(TripsPerPage).ToList();

            var tripsList = new TripsListViewModel()
            {
                TotalPages = totalpages,
                CurrentPage = page,
                Trips = tripsToShow
            };

            return this.View(tripsList);
        }
    }
}
