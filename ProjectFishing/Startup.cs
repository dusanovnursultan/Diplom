using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectFishing.Startup))]
namespace ProjectFishing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
