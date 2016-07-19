namespace iRacing.SetupLibrary
{
    public interface ILeftFrontTire
    {
        string ColdPressure { get; }
        string LastHotPressure { get; }
        string LastTempsOMI { get; }
        string TreadRemaining { get; }
    }
}