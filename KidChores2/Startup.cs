using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KidChores2.Startup))]
namespace KidChores2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
