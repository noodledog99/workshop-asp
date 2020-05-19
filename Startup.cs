using Microsoft.Owin;
using Owin;
using workshop_asp.Data;

[assembly: OwinStartupAttribute(typeof(workshop_asp.Startup))]
namespace workshop_asp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
