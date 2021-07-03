using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShelfBook.Startup))]
namespace ShelfBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
