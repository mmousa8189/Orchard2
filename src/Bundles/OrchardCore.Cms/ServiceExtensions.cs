using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orchard.Environment.Commands;
using Orchard.Environment.Extensions;
using Orchard.Environment.Extensions.Manifests;
using Orchard.Environment.Shell.Data;

namespace Microsoft.AspNetCore.Modules
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddOrchardCms(this IServiceCollection services)
        {
            return AddOrchardCms(services, null);
        }

        public static IServiceCollection AddOrchardCms(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddManifestDefinition("Theme.txt", "theme");
            services.AddExtensionLocation("Themes");
            services.AddSitesFolder("App_Data", "Sites");
            services.AddCommands();
            services.AddModuleServices(modules => 
            {
                if (configuration != null)
                {
                    modules.AddConfiguration(configuration);
                }

                modules.WithDefaultFeatures("Orchard.Mvc", "Orchard.Settings", "Orchard.Setup", "Orchard.Recipes", "Orchard.Commons");
            });

            return services;
        }
    }
}
