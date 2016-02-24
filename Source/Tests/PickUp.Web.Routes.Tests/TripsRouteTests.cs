namespace PickUp.Web.Routes.Tests
{
    using System.Web.Routing;
    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class TripsRouteTests
    {
        [Test]
        public void TestRouteById()
        {
            const string Url = "/Trip/MTUuMTIzMTIzMTMxMjM===";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<TripsController>(c => c.ById("MTUuMTIzMTIzMTMxMjM==="));
        }

        [Test]
        public void TestRouteTripsListDefault()
        {
            const string Url = "/Trips";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<TripsListController>(c => c.Index(1, string.Empty, string.Empty, string.Empty));
        }

        [Test]
        public void TestRouteTripsListWithGivenOnlyFromLocation()
        {
            const string Url = "/TripsList?from=Балчик&to=&datepicker=&page=1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<TripsListController>(c => c.Index(1, "Балчик", string.Empty, string.Empty));
        }

        [Test]
        public void TestRouteTripsListWithGivenOnlyТоLocation()
        {
            const string Url = "/TripsList?from=&to=Балчик&datepicker=&page=1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<TripsListController>(c => c.Index(1, string.Empty, "Балчик", string.Empty));
        }

        [Test]
        public void TestRouteTripsListWithGivenFromAndТоLocations()
        {
            const string Url = "/TripsList?from=Балчик&to=Балчик&datepicker=&page=1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<TripsListController>(c => c.Index(1, "Балчик", "Балчик", string.Empty));
        }

        [Test]
        public void TestRouteTripsListWithGivenStartDate()
        {
            const string Url = "/TripsList?from=&to=&datepicker=15.02.2016&page=1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<TripsListController>(c => c.Index(1, string.Empty, string.Empty, "15.02.2016"));
        }

        [Test]
        public void TestRouteTripsListWithGivenStartDateAndFromLocation()
        {
            const string Url = "/TripsList?from=Балчик&to=&datepicker=15.02.2016&page=1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<TripsListController>(c => c.Index(1, "Балчик", string.Empty, "15.02.2016"));
        }

        [Test]
        public void TestRouteTripsListWithGivenStartDateAndToLocation()
        {
            const string Url = "/TripsList?from=&to=Балчик&datepicker=15.02.2016&page=1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<TripsListController>(c => c.Index(1, string.Empty, "Балчик", "15.02.2016"));
        }

        [Test]
        public void TestRouteTripsListWithGivenStartDateFromAndToLocations()
        {
            const string Url = "/TripsList?from=Балчик&to=Балчик&datepicker=15.02.2016&page=1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<TripsListController>(c => c.Index(1, "Балчик", "Балчик", "15.02.2016"));
        }

        [Test]
        public void TestRouteTrips()
        {
            const string Url = "/Trips/Index";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<TripsController>(c => c.Index());
        }

        [Test]
        public void TestRouteUsers()
        {
            const string Url = "/Users/Details";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<UsersController>(c => c.Details());
        }

        [Test]
        public void TestRouteMyTrips()
        {
            const string Url = "/MyTrips/Index";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<MyTripsController>(c => c.Index());
        }

        [Test]
        public void TestRouteLocations()
        {
            const string Url = "/Locations/GetAllLocations";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<LocationsController>(c => c.GetAllLocations());
        }

        [Test]
        public void TestRouteHome()
        {
            const string Url = "/Home/Index";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<HomeController>(c => c.Index());
        }

        [Test]
        public void TestRouteEdit()
        {
            const string Url = "/Edit/EditTrip/1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<EditController>(c => c.EditTrip(1));
        }
    }
}
