﻿namespace PickUp.Web.ViewModels.Users
{
    using System.Collections.Generic;
    using PickUp.Data.Models;
    using PickUp.Web.Infrastructure.Mapping;

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

                return ratesSum;
            }
        }

        public ICollection<Rate> Rates { get; set; }
    }
}
