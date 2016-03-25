using System;
using System.Collections.Generic;

namespace SetupParameterLibrary
{
    public interface ISetupGroup
    {
        int DisplayIndex { get; set; }
        string Key { get; set; }
        string Name { get; set; }
        Guid SetupGroupId { get; set; }
        IList<SetupSubGroup> SetupSubGroups { get; set; }
    }
}