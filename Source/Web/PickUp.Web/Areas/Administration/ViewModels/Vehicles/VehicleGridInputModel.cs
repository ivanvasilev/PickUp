using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickUp.Web.Areas.Administration.ViewModels.Vehicles
{
    public class VehicleGridInputModel
    {
        public int Id { get; set; }

        public string RegistrationNumber { get; set; }

        public int? Year { get; set; }

        public string Color { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }
    }
}