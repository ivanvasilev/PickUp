﻿namespace PickUp.Web.ViewModels.Trips
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using PickUp.Data.Models;
    using PickUp.Web.Infrastructure.Mapping;
    using PickUp.Web.ViewModels.Users;

    public class TripDetailsViewModel : IMapFrom<Trip>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public int AvailableSeats { get; set; }

        public string Driver { get; set; }

        public IEnumerable<ApplicationUser> Passengers { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Trip, TripDetailsViewModel>()
                .ForMember(x => x.From, opt => opt.MapFrom(x => x.From.Name));

            configuration.CreateMap<Trip, TripDetailsViewModel>()
                .ForMember(x => x.To, opt => opt.MapFrom(x => x.To.Name));

            configuration.CreateMap<Trip, TripDetailsViewModel>()
                .ForMember(x => x.Driver, opt => opt.MapFrom(x => x.Driver.Email));
        }
    }
}
