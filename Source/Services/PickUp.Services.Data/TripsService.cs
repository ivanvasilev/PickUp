namespace PickUp.Services.Data
{
    using System.Linq;
    using PickUp.Data.Common;
    using PickUp.Data.Models;
    using PickUp.Services.Data.Contracts;
    using Web;

    public class TripsService : ITripsService
    {
        private readonly IIdentifierProvider identifierProvider;
        private IDbRepository<Trip> trips;

        public TripsService(IDbRepository<Trip> trips, IIdentifierProvider identifierProvider)
        {
            this.trips = trips;
            this.identifierProvider = identifierProvider;
        }

        public void Create(Trip trip)
        {
            this.trips.Add(trip);
            this.trips.Save();
        }

        public IQueryable<Trip> GetAll()
        {
            return this.trips.All();
        }

        public Trip GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var trip = this.trips.GetById(intId);
            return trip;
        }

        public void Update(Trip trip)
        {
            this.trips.Save();
        }

        public void Delete(Trip trip)
        {
            this.trips.Delete(trip);
            this.trips.Save();
        }

        public Trip GetByIntId(int id)
        {
            var trip = this.trips.GetById(id);
            return trip;
        }
    }
}
