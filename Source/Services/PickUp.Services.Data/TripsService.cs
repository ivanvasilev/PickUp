namespace PickUp.Services.Data
{
    using System;
    using System.Linq;
    using PickUp.Services.Data.Contracts;
    using PickUp.Data.Common;
    using PickUp.Data.Models;

    public class TripsService : ITripsService
    {
        private IDbRepository<Trip> trips;

        public TripsService(IDbRepository<Trip> trips)
        {
            this.trips = trips;
        }

        public IQueryable<Trip> GetAll()
        {
            return this.trips.All();
        }
    }
}
