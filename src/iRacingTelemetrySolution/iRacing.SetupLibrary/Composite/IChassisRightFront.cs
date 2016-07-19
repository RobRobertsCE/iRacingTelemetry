namespace iRacing.SetupLibrary
{
    public interface IChassisRightFront
    {
        string BumpStiffness { get; set; }
        string Camber { get; set; }
        string Caster { get; set; }
        string CornerWeight { get; set; }
        string ReboundStiffness { get; set; }
        string RideHeight { get; set; }
        string ShockCollarOffset { get; set; }
        string SpringRate { get; set; }
    }
}