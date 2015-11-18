using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VejleSygehus.Startup))]
namespace VejleSygehus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
