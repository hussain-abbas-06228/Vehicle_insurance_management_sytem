using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(vimseproject.Startup))]
namespace vimseproject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
