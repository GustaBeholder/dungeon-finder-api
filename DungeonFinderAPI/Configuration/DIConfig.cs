using DungeonFinderDomain.Interface.Repository;
using DungeonFinderDomain.Interface.Service;
using DungeonFinderDomain.Services;
using DungeonFinderInfra.DbConnect;
using DungeonFinderInfra.Repository;

namespace DungeonFinderAPI.Configuration
{
    public static class DIConfig
    {
        public static IServiceCollection DependencyInjection(this IServiceCollection service)
        {
            service.AddScoped<DbSession>();
            //Services
            service.AddScoped<IMesaService, MesaService>();
            service.AddScoped<ISistemaService, SistemaService>();
            service.AddScoped<IJogadorService, JogadorService>();
            service.AddScoped<IUsuarioService, UsuarioService>();

            //Repositories
            service.AddScoped<IMesaRepository, MesaRepository>();
            service.AddScoped<ISistemaRepository, SistemaRepository>();
            service.AddScoped<IJogadorRepository, JogadorRepository>();
            service.AddScoped<IUsuarioRepository, UsuarioRepository>();


            return service;

        }
    }
}
