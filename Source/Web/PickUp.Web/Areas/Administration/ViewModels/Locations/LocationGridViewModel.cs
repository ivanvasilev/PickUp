namespace PickUp.Web.Areas.Administration.ViewModels.Locations
{
    using System;
    using PickUp.Data.Models;
    using PickUp.Web.Infrastructure.Mapping;

    public class LocationGridViewModel : IMapFrom<Location>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
