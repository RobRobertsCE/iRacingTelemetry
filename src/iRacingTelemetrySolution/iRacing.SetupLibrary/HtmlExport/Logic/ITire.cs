namespace SetupExportParser.Logic
{
    public interface ITire
    {
        double ColdPSI { get; set; }
        double LastHotPSI { get; set; }
        double PSIGain { get; }
        double LastTempO { get; set; }
        double LastTempM { get; set; }
        double LastTempI { get; set; }
        double TempSpread { get; }
        int TreadRemainingO { get; set; }
        int TreadRemainingM { get; set; }
        int TreadRemainingI { get; set; }
        double WearSpread { get; }
        double Stagger { get; set; }
    }
}
