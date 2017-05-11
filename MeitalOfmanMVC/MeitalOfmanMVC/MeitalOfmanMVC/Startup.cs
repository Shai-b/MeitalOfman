using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeitalOfmanMVC.Startup))]
namespace MeitalOfmanMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
