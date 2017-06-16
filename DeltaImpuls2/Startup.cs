using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeltaImpuls2.Startup))]
namespace DeltaImpuls2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
