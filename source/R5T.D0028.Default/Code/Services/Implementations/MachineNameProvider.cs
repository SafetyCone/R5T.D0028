using System;

using R5T.T0007;

using IStringlyTypedMachineNameProvider = R5T.D0027.IMachineNameProvider;using R5T.T0064;


namespace R5T.D0028.Default
{[ServiceImplementationMarker]
    public class MachineNameProvider : IMachineNameProvider,IServiceImplementation
    {
        private IStringlyTypedMachineNameProvider StringlyTypedMachineNameProvider { get; }


        public MachineNameProvider(IStringlyTypedMachineNameProvider stringlyTypedMachineNameProvider)
        {
            this.StringlyTypedMachineNameProvider = stringlyTypedMachineNameProvider;
        }

        public MachineName GetMachineName()
        {
            var machineNameString = this.StringlyTypedMachineNameProvider.GetMachineName();

            var machineName = machineNameString.AsMachineName();
            return machineName;
        }
    }
}
