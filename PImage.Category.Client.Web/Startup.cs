using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PImage.Category.Client.Web.Startup))]
namespace PImage.Category.Client.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
