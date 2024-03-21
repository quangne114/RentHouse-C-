using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DACS_ThueTro.Startup))]
namespace DACS_ThueTro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
