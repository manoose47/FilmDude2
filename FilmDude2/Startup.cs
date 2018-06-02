using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilmDude2.Startup))]
namespace FilmDude2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
