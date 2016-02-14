namespace PickUp.Services.Data.Contracts
{
    using System.Linq;

    public interface ITripsService
    {
        IQueryable GetAll();
    }
}
