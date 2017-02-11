using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnLineShop.Web.Startup))]
namespace OnLineShop.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
