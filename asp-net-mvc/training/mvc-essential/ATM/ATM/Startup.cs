using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ATM.Startup))]
namespace ATM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
