using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickUp.Web.Controllers
{
    public class TripsController : Controller
    {
        // GET: Trips
        public ActionResult Index()
        {
            return this.View();
        }
    }
}