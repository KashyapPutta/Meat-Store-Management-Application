using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TakeAwayMeat.Startup))]
namespace TakeAwayMeat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
