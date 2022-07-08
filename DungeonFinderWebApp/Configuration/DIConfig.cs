
using DungeonFinderWebApp.Domain.Interface.Service;
using DungeonFinderWebApp.Domain.Services;

namespace DungeonFinderWebApp.Configuration
{
    public static class DIConfig
    {

        public static IServiceCollection DependencyInjection(this IServiceCollection service)
        {
            //services

            service.AddHttpClient<ILoginService, LoginService>();


            return service;

        }
    }
}
