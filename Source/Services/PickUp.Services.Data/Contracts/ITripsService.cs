namespace PickUp.Services.Data.Contracts
{
    using System.Linq;
    using PickUp.Data.Models;

    public interface ITripsService
    {
        IQueryable<Trip> GetAll();

        void Create(Trip trip);

        Trip GetById(string id);

        Trip GetByIntId(int id);

        void Update(Trip joke);

        void Delete(Trip joke);
    }
}
