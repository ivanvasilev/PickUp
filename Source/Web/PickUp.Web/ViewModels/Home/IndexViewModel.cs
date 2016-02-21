namespace PickUp.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<TripViewModel> Trips { get; set; }
    }
}
