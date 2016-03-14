namespace SetupExportParser.SetupModels.LMSC
{
    public interface ILMSCSetup : Logic.ISetup
    {
        string TapeConfiguration { get; set; }
        new ILMSCRearSuspension LRSuspension { get; set; }
        new ILMSCRearSuspension RRSuspension { get; set; }
    }
}
