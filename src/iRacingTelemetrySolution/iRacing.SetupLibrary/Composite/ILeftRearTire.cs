namespace iRacing.SetupLibrary
{
    public interface ILeftRearTire
    {
        string ColdPressure { get; set; }
        string LastHotPressure { get; set; }
        string LastTempsOMI { get; set; }
        string TreadRemaining { get; set; }
    }
}