using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoshoSoft.ForumSystem.Web.Startup))]
namespace GoshoSoft.ForumSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
