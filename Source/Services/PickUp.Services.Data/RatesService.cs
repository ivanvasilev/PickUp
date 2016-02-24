namespace PickUp.Services.Data
{
    using System;
    using System.Linq;
    using PickUp.Data.Common;
    using PickUp.Data.Models;
    using PickUp.Services.Data.Contracts;

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

        public IQueryable<Rate> GetAll()
        {
            return this.rates.All();
        }

        public void Update(Rate rate)
        {
            this.rates.Save();
        }
    }
}
