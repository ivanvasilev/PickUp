using PickUp.Data.Models;
using PickUp.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickUp.Web.ViewModels.Users
{
    public class PassengerViewModel : IMapFrom<ApplicationUser>
    {
        public string UserName { get; set; }

        public decimal Rating
        {
            get
            {
                var ratesSum = 0;
                var count = this.Rates.Count;
                if (count == 0)
                {
                    return 0;
                }

                foreach (var rate in this.Rates)
                {
                    ratesSum += rate.Value;
                }

                var rating = ratesSum / (decimal)count;
                return rating;
            }
        }

        public ICollection<Rate> Rates { get; set; }
    }
}