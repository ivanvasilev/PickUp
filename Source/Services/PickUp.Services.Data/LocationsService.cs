namespace PickUp.Services.Data
{
    using System;
    using System.Linq;
    using PickUp.Data.Models;
    using PickUp.Services.Data.Contracts;
    using PickUp.Data.Common;

    public class LocationsService : ILocationsService
    {
        private IDbRepository<Location> locations;

        public LocationsService(IDbRepository<Location> locations)
        {
            this.locations = locations;
        }

        public IQueryable<Location> GetAll()
        {
            return this.locations.All();
        }
    }
}
