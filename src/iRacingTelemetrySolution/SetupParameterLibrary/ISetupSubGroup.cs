using System;
using System.Collections.Generic;

namespace SetupParameterLibrary
{
    public interface ISetupSubGroup
    {
        int DisplayIndex { get; set; }
        string Key { get; set; }
        string Name { get; set; }
        Guid SetupGroupId { get; set; }
        IList<SetupParameter> SetupParameters { get; set; }
        Guid SetupSubGroupId { get; set; }
    }
}