using PickUp.Services.Data.Contracts;
using PickUp.Web.Infrastructure.Mapping;
using PickUp.Web.ViewModels.TripsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickUp.Web.Controllers
{
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
        public ActionResult Index(int id = 1)
        {
            var locations = this.locations.GetAll().ToList();
            this.ViewData["Locations"] = new SelectList(locations, "Name", "Name");

            var page = id;
                var pagesToSkip = (page - 1) * TripsPerPage;
                var allTrips = this.trips.GetAll().Count();
                var totalpages = (int)Math.Ceiling(allTrips / (decimal)TripsPerPage);

                var tripsToShow = this.trips
                    .GetAll()
                    .To<PageableTripViewModel>()
                    .ToList();

            //if (!string.IsNullOrEmpty(from))
            //{
            //    tripsToShow = tripsToShow.Where(x => x.From == from).ToList();
            //}

            //if (!string.IsNullOrEmpty(to))
            //{
            //    tripsToShow = tripsToShow.Where(x => x.To == to).ToList();
            //}

            //if (!string.IsNullOrEmpty(datepicker))
            //{
            //    var givenDate = DateTime.Parse(datepicker);
            //    tripsToShow = tripsToShow.Where(x => x.StartDate >= givenDate).ToList();
            //}

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