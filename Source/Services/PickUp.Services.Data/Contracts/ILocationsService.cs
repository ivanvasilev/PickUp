namespace PickUp.Services.Data.Contracts
{
    using System.Linq;
    using PickUp.Data.Models;

    public interface ILocationsService
    {
        IQueryable<Location> GetAll();

        void Create(Location entity);

        void Update(Location entity);

        Location GetById(int id);

        void Delete(Location tripToDelete);
    }
}
