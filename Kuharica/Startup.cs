using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kuharica.Startup))]
namespace Kuharica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
