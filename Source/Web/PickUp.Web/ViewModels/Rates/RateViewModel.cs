using PickUp.Data.Models;
using PickUp.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickUp.Web.ViewModels.Rates
{
    public class RateViewModel : IMapFrom<Rate>
    {
        public int Value { get; set; }
    }
}