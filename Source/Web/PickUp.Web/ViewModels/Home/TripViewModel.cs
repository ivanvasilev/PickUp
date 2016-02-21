using PickUp.Data.Models;
using PickUp.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace PickUp.Web.ViewModels.Home
{
    public class TripViewModel : IMapFrom<Trip>, IHaveCustomMappings
    {
        public string From { get; set; }

        public string To { get; set; }

        public DateTime StartDate { get; set; }

        public int AvailableSeats { get; set; }

        public string Driver { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Trip, TripViewModel>()
                .ForMember(x => x.From, opt => opt.MapFrom(x => x.From.Name));

            configuration.CreateMap<Trip, TripViewModel>()
                .ForMember(x => x.To, opt => opt.MapFrom(x => x.To.Name));

            configuration.CreateMap<Trip, TripViewModel>()
                .ForMember(x => x.Driver, opt => opt.MapFrom(x => x.Driver.UserName));
        }
    }
}