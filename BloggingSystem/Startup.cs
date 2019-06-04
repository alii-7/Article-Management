using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BloggingSystem.Startup))]
namespace BloggingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
