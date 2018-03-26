using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoWhileTrain.Startup))]
namespace DoWhileTrain
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
