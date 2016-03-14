namespace SetupExportParser.SetupModels.LMSC
{
    public interface ILMSCRearSuspension : Logic.IRearSuspension
    {
        string TruckArmMount { get; set; }
        double TruckArmPreload { get; set; }
    }
}
