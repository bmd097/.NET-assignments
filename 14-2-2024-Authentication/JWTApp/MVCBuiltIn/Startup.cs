using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCBuiltIn.Startup))]
namespace MVCBuiltIn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
