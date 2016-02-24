namespace PickUp.Services.Data.Contracts
{
    using System.Linq;
    using PickUp.Data.Models;

    public interface IRatesService
    {
        void Create(Rate vote);

        IQueryable<Rate> GetAll();

        void Update(Rate rate);
    }
}
