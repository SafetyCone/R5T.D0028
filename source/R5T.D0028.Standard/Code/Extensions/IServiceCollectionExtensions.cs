using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0028.Default;

using R5T.Dacia;

using IStringlyTypedMachineNameProvider = R5T.D0027.IMachineNameProvider;


namespace R5T.D0028.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static (
            IServiceAction<IMachineNameProvider> Main,
            IServiceAction<IStringlyTypedMachineNameProvider> StringlyTypedMachineNameProviderAction
            )
            AddMachineNameProviderAction(this IServiceCollection services)
        {
            var stringlyTypedMachineNameProviderAction = R5T.D0027.Default.IServiceCollectionExtensions.AddMachineNameProviderAction(services);

            var machineNameProviderAction = services.AddMachineNameProviderAction(stringlyTypedMachineNameProviderAction);

            return (
                machineNameProviderAction,
                stringlyTypedMachineNameProviderAction);
        }

        public static IServiceCollection AddMachineNameProvider(this IServiceCollection services)
        {
            var machineNameProviderAction = services.AddMachineNameProviderAction();

            services.Run(machineNameProviderAction.Main);

            return services;
        }
    }
}
