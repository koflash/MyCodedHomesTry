using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodedHomes.Web2.Startup))]
namespace CodedHomes.Web2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
