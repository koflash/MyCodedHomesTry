using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodedHomes.Admin.Startup))]
namespace CodedHomes.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
