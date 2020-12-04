using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Chess20.Startup))]
namespace Chess20
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
