using System;

namespace iRacing.SetupLibrary.Parsers
{
    public interface ISetupParser : IDisposable
    {
        ICarSetup GetSetup(Vehicles vehicle, string setupData);
    }
}
