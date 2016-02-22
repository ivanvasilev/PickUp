namespace PickUp.Services.Data
{
    using System.Linq;
    using PickUp.Data.Common;
    using PickUp.Data.Models;
    using PickUp.Services.Data.Contracts;

    public class LocationsService : ILocationsService
    {
        private IDbRepository<Location> locations;

        public LocationsService(IDbRepository<Location> locations)
        {
            this.locations = locations;
        }

        public void Create(Location entity)
        {
            this.locations.Add(entity);
            this.locations.Save();
        }

        public void Delete(Location tripToDelete)
        {
            this.locations.Delete(tripToDelete);
            this.locations.Save();
        }

        public IQueryable<Location> GetAll()
        {
            return this.locations.All();
        }

        public Location GetById(int id)
        {
            return this.locations.GetById(id);
        }

        public void Update(Location entity)
        {
            this.locations.Save();
        }
    }
}
