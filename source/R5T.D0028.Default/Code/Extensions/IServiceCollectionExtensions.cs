using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using IStringlyTypedMachineNameProvider = R5T.D0027.IMachineNameProvider;


namespace R5T.D0028.Default
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Add <see cref="MachineNameProvider"/> implementation of <see cref="IMachineNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddMachineNameProvider(this IServiceCollection services,
            IServiceAction<IStringlyTypedMachineNameProvider> stringlyTypedMachineNameProviderAction)
        {
            services
                .AddSingleton<IMachineNameProvider, MachineNameProvider>()
                .Run(stringlyTypedMachineNameProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Add <see cref="MachineNameProvider"/> implementation of <see cref="IMachineNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IMachineNameProvider> AddMachineNameProviderAction(this IServiceCollection services,
            IServiceAction<IStringlyTypedMachineNameProvider> stringlyTypedMachineNameProviderAction)
        {
            var serviceAction = ServiceAction.New<IMachineNameProvider>(() => services.AddMachineNameProvider(
                stringlyTypedMachineNameProviderAction));

            return serviceAction;
        }
    }
}
