using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(baitapltw.Startup))]
namespace baitapltw
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
