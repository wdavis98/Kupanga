using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kupanga.Startup))]
namespace Kupanga
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
