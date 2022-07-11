using DungeonFinderWebApp.Domain.Extensions;

namespace DungeonFinderWebApp.Configuration
{
    public static class WebAppConfig
    {
        public static void AddMvcConfiguration(this IServiceCollection services)
        {
            services.AddControllersWithViews();

        }
    }
}
