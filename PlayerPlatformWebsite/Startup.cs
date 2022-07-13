using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(PlayerPlatformWebsite.Startup))]
namespace PlayerPlatformWebsite
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}