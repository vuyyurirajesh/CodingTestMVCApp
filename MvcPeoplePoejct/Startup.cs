using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcPeoplePoejct.Startup))]
namespace MvcPeoplePoejct
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
