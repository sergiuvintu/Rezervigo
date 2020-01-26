using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rezervigo.Startup))]
namespace Rezervigo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
