using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Welenda.lk.Startup))]
namespace Welenda.lk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
