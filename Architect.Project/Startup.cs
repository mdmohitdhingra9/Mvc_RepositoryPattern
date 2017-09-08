using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Architect.Project.Startup))]
namespace Architect.Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
