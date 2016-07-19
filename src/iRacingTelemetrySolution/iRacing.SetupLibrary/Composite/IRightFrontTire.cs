namespace iRacing.SetupLibrary
{
    public interface IRightFrontTire
    {
        string ColdPressure { get; set; }
        string LastHotPressure { get; set; }
        string LastTempsIMO { get; set; }
        string Stagger { get; set; }
        string TreadRemaining { get; set; }
    }
}