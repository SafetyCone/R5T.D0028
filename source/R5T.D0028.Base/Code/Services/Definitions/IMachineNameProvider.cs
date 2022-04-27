using System;

using R5T.T0007;
using R5T.T0064;


namespace R5T.D0028
{
    [ServiceDefinitionMarker]
    public interface IMachineNameProvider : IServiceDefinition
    {
        MachineName GetMachineName();
    }
}
