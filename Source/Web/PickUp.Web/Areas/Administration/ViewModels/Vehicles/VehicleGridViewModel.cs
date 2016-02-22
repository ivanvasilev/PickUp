namespace PickUp.Web.Areas.Administration.ViewModels.Vehicles
{
    using System;
    using AutoMapper;
    using PickUp.Data.Models;
    using PickUp.Web.Infrastructure.Mapping;

    public class VehicleGridViewModel : IMapFrom<Vehicle>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string RegistrationNumber { get; set; }

        public int? Year { get; set; }

        public string Color { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string DriverName { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Vehicle, VehicleGridViewModel>()
                .ForMember(x => x.DriverName, opt => opt.MapFrom(x => x.Driver.UserName));
        }
    }
}
