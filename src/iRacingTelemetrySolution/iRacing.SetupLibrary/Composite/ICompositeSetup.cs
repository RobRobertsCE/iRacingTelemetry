using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.SetupLibrary
{
    public interface ICompositeSetup
    {
        ISetupChassis Chassis { get; }
        ISetupTires Tires { get; }
    }
}
