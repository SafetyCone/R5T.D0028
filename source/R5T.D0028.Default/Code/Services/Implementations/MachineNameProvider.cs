using System;

using R5T.T0007;

using IStringlyTypedMachineNameProvider = R5T.D0027.IMachineNameProvider;


namespace R5T.D0028.Default
{
    public class MachineNameProvider : IMachineNameProvider
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
