namespace PickUp.Services.Data.Contracts
{
    using PickUp.Data.Models;
    using System.Linq;

    public interface ITripsService
    {
        IQueryable<Trip> GetAll();

        void Create(Trip trip);

        Trip GetById(string id);
    }
}
