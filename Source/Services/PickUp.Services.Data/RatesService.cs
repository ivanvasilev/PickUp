using PickUp.Data.Common;
using PickUp.Data.Models;
using PickUp.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickUp.Services.Data
{
    public class RatesService : IRatesService
    {
        private IDbRepository<Rate> rates;

        public RatesService(IDbRepository<Rate> rates)
        {
            this.rates = rates;
        }

        public void Create(Rate rate)
        {
            this.rates.Add(rate);
            this.rates.Save();
        }
    }
}
