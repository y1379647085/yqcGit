using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyMvcStudy.Startup))]
namespace MyMvcStudy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
