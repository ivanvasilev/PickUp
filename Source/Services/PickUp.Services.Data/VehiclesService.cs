namespace PickUp.Services.Data
{
    using System;
    using PickUp.Services.Data.Contracts;
    using PickUp.Data.Models;
    using PickUp.Data.Common;

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
    }
}
