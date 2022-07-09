

using DungeonFinderWebApp.Domain.Interface.Services;
using DungeonFinderWebApp.Domain.Services;

namespace DungeonFinderWebApp.Configuration
{
    public static class DIConfig
    {
        public static IServiceCollection DependencyInjection(this IServiceCollection service)
        {

            //Services
            service.AddHttpClient<ILoginService, LoginService>();



            return service;

        }
    }
}
