using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Resume_Portal.Startup))]
namespace Resume_Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
