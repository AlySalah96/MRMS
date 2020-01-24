using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BRMS.Startup))]
namespace BRMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
