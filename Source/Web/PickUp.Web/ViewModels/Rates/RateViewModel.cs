namespace PickUp.Web.ViewModels.Rates
{
    using PickUp.Data.Models;
    using PickUp.Web.Infrastructure.Mapping;

    public class RateViewModel : IMapFrom<Rate>
    {
        public int Value { get; set; }
    }
}
