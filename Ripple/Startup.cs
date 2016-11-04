using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ripple.Startup))]
namespace Ripple
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
