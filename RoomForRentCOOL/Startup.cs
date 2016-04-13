using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoomForRentCOOL.Startup))]
namespace RoomForRentCOOL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
