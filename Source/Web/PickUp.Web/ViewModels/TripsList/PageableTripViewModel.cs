namespace PickUp.Web.ViewModels.TripsList
{
    using System;
    using AutoMapper;
    using PickUp.Data.Models;
    using PickUp.Services.Web;
    using PickUp.Web.Infrastructure.Mapping;

    public class PageableTripViewModel : IMapFrom<Trip>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/Trip/{identifier.EncodeId(this.Id)}";
            }
        }

        public DateTime StartDate { get; set; }

        public int AvailableSeats { get; set; }

        public string Driver { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Trip, PageableTripViewModel>()
                .ForMember(x => x.From, opt => opt.MapFrom(x => x.From.Name));

            configuration.CreateMap<Trip, PageableTripViewModel>()
                .ForMember(x => x.To, opt => opt.MapFrom(x => x.To.Name));

            configuration.CreateMap<Trip, PageableTripViewModel>()
                .ForMember(x => x.Driver, opt => opt.MapFrom(x => x.Driver.UserName));
        }
    }
}
