namespace PickUp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Microsoft.AspNet.Identity;
    using PickUp.Data.Models;
    using PickUp.Services.Data.Contracts;

    [Authorize]
    public class RatesController : Controller
    {
        private IUsersService users;
        private IRatesService rates;

        public RatesController(IUsersService users, IRatesService rates)
        {
            this.users = users;
            this.rates = rates;
        }

        [HttpPost]
        public ActionResult RateUser(string userId, int rateValue)
        {
            var raterId = this.User.Identity.GetUserId();
            var rate = this.rates
                .GetAll()
                .Where(x => x.RaterId == raterId &&
                            x.RatedId == userId)
                .FirstOrDefault();

            if (rate != null)
            {
                rate.Value = rateValue;
                this.rates.Update(rate);

                return this.Json(new { VoteValue = rate.Value });
            }
            else
            {
                var rateToAdd = new Rate()
                {
                    RaterId = this.User.Identity.GetUserId(),
                    RatedId = userId,
                    Value = rateValue
                };

                this.rates.Create(rateToAdd);
                var ratedUser = this.users.GetById(userId);
                ratedUser.Rates.Add(rateToAdd);
                this.users.Update(ratedUser);

                return this.Json(new { VoteValue = rateToAdd.Value });
            }
        }
    }
}
