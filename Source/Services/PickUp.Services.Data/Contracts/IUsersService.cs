using PickUp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickUp.Services.Data.Contracts
{
    public interface IUsersService
    {
        ApplicationUser GetById(string id);

        IQueryable<ApplicationUser> GetAll();

        void Update(ApplicationUser user);

        void Create(ApplicationUser user, string password);

        void Delete(ApplicationUser user);
    }
}
