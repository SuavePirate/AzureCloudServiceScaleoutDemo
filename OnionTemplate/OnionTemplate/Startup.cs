using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(OnionTemplate.Startup))]
namespace OnionTemplate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = IoCConfig.RegisterDependencies();
        }
    }
}
