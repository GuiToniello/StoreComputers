using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Uniplac.Trabalho_Final.Apresentacao.Web.Startup))]
namespace Uniplac.Trabalho_Final.Apresentacao.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
