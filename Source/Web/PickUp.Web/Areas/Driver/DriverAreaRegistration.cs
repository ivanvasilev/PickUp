﻿namespace PickUp.Web.Areas.Driver
{
    using System.Web.Mvc;

    public class DriverAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Driver";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Driver_default",
                "Driver/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}
