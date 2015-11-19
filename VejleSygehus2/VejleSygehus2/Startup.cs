using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VejleSygehus2.Startup))]
namespace VejleSygehus2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
