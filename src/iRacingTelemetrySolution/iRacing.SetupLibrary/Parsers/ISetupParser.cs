using System;

namespace iRacing.SetupLibrary.Parsers
{
    public interface ISetupParser
    {
        ICarSetup GetSetup(Vehicles vehicle, string setupData);
    }
}
