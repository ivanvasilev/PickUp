using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(PickUp.Web.Startup))]

namespace PickUp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
