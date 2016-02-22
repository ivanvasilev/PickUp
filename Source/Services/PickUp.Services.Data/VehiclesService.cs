namespace PickUp.Services.Data
{
    using System.Linq;
    using PickUp.Data.Common;
    using PickUp.Data.Models;
    using PickUp.Services.Data.Contracts;

    public class VehiclesService : IVehiclesService
    {
        private IDbRepository<Vehicle> vehicles;

        public VehiclesService(IDbRepository<Vehicle> vehicles)
        {
            this.vehicles = vehicles;
        }

        public void Create(Vehicle vehicle)
        {
            this.vehicles.Add(vehicle);
            this.vehicles.Save();
        }

        public void Delete(Vehicle vehicle)
        {
            this.vehicles.Delete(vehicle);
            this.vehicles.Save();
        }

        public IQueryable<Vehicle> GetAll()
        {
            return this.vehicles.All();
        }

        public Vehicle GetById(int id)
        {
            return this.vehicles.GetById(id);
        }

        public void Update(Vehicle entity)
        {
            this.vehicles.Save();
        }
    }
}
