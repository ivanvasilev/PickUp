namespace PickUp.Services.Data.Contracts
{
    using System.Linq;
    using PickUp.Data.Models;

    public interface ILocationsService
    {
        IQueryable<Location> GetAll();

    }
}
