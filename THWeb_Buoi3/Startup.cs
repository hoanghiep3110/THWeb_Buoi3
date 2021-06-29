using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(THWeb_Buoi3.Startup))]
namespace THWeb_Buoi3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
