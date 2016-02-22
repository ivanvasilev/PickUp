namespace PickUp.Services.Data.Contracts
{
    using System.Linq;
    using PickUp.Data.Models;

    public interface IVehiclesService
    {
        void Create(Vehicle vehicle);

        IQueryable<Vehicle> GetAll();

        void Update(Vehicle entity);

        Vehicle GetById(int id);

        void Delete(Vehicle vehicle);
    }
}
