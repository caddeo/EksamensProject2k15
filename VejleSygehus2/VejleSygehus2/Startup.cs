using Microsoft.Owin;
using Owin;
using VejleSygehus2;

[assembly: OwinStartup(typeof (Startup))]

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