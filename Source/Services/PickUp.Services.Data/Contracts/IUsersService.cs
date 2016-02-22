namespace PickUp.Services.Data.Contracts
{
    using System.Linq;
    using PickUp.Data.Models;

    public interface IUsersService
    {
        ApplicationUser GetById(string id);

        IQueryable<ApplicationUser> GetAll();

        void Update(ApplicationUser user);

        void Create(ApplicationUser user, string password);

        void Delete(ApplicationUser user);
    }
}
