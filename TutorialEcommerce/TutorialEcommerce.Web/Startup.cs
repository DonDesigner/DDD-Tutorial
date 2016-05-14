using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TutorialEcommerce.Web.Startup))]
namespace TutorialEcommerce.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
