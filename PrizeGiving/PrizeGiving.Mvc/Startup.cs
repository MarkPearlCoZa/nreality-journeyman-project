using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrizeGiving.Mvc.Startup))]
namespace PrizeGiving.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
