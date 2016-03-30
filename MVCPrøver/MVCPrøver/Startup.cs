using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCPrøver.Startup))]
namespace MVCPrøver
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
