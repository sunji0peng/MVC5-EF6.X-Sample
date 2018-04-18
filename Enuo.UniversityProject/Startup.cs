using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Enuo.UniversityProject.Startup))]
namespace Enuo.UniversityProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
