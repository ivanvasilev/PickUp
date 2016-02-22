﻿namespace PickUp.Web.Areas.Administration.ViewModels
{
    using System;
    using PickUp.Data.Models;
    using PickUp.Web.Infrastructure.Mapping;

    public class UserGridViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
