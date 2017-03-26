using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Goomer.Web.Startup))]
namespace Goomer.Web
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
