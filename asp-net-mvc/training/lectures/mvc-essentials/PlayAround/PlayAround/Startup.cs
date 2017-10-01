using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlayAround.Startup))]
namespace PlayAround
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
