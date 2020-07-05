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
            IServiceAction<IMachineNameProvider> MachineNameProviderAction,
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
#pragma warning disable IDE0042 // Deconstruct variable declaration
            var machineNameProviderAction = services.AddMachineNameProviderAction();
#pragma warning restore IDE0042 // Deconstruct variable declaration

            services.Run(machineNameProviderAction.MachineNameProviderAction);

            return services;
        }
    }
}
