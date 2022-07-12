

using DungeonFinderWebApp.Domain.Interface.Services;
using DungeonFinderWebApp.Domain.Services;

namespace DungeonFinderWebApp.Configuration
{
    public static class DIConfig
    {

        public static IServiceCollection DependencyInjection(this IServiceCollection service)
        {
            //services

            //Services
            service.AddHttpClient<ILoginService, LoginService>();
            service.AddHttpClient<IMesaService, MesaService>();
            service.AddHttpClient<ISistemaService, SistemaService>();

            return service;

        }
    }
}
