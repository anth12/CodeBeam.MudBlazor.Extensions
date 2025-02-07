﻿using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MudBlazor.Services;
using MudExtensions.Utilities;

namespace MudExtensions.Services
{
    /// <summary>
    /// 
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ExtensionServiceCollectionExtensions
    {
        /// <summary>
        /// Adds ScrollManagerExtended as a transient instance.
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static IServiceCollection AddScrollManagerExtended(this IServiceCollection services)
        {
            services.TryAddTransient<IScrollManagerExtended, ScrollManagerExtended>();
            return services;
        }

        /// <summary>
        /// Adds CssManager as a transient instance.
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static IServiceCollection AddMudCssManager(this IServiceCollection services)
        {
            services.TryAddTransient<MudCssManager>();
            return services;
        }

        /// <summary>
        /// Adds TeleportManager as a transient instance.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMudTeleportManager(this IServiceCollection services)
        {
            services.TryAddTransient<MudTeleportManager>();
            return services;
        }

        /// <summary>
        /// Adds common services required by MudBlazor components
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">Defines options for all MudBlazor services.</param>
        /// <returns>Continues the IServiceCollection chain.</returns>
        public static IServiceCollection AddMudExtensions(this IServiceCollection services, MudServicesConfiguration? configuration = null)
        {
            configuration ??= new MudServicesConfiguration();
            return services
                .AddScrollManagerExtended()
                .AddMudCssManager()
                .AddMudTeleportManager();
        }

        /// <summary>
        /// Adds common services required by MudBlazor components
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">Defines options for all MudBlazor services.</param>
        /// <returns>Continues the IServiceCollection chain.</returns>
        public static IServiceCollection AddMudExtensions(this IServiceCollection services, Action<MudServicesConfiguration> configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            var options = new MudServicesConfiguration();
            configuration(options);
            return services
                .AddScrollManagerExtended()
                .AddMudCssManager()
                .AddMudTeleportManager();
        }
    }
}
