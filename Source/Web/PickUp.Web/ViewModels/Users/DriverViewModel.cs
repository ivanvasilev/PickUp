namespace PickUp.Web.ViewModels.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using Infrastructure.Mapping;
    using Rates;

    public class DriverViewModel : IMapFrom<ApplicationUser>
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