using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Agenda.Startup))]
namespace Agenda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}