using Microsoft.AspNet.Identity;
using PickUp.Data.Models;
using PickUp.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickUp.Web.Controllers
{
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

            return this.Json(new { VoteValue = rateToAdd.Value});
        }
    }
}