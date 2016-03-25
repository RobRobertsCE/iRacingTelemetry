using System;

namespace SetupParameterLibrary
{
    public interface ISetupParameter
    {
        int DisplayIndex { get; set; }
        bool IsTranslatable { get; set; }
        string Key { get; set; }
        string Name { get; set; }
        string OriginalSuffix { get; set; }
        Guid SetupParameterId { get; set; }
        Guid SetupSubGroupId { get; set; }
        string TranslatedSuffix { get; set; }
    }
}