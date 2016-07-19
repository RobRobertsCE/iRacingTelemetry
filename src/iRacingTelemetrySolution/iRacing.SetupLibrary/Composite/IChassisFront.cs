namespace iRacing.SetupLibrary
{
    public interface IChassisFront
    {
        string AttachLeftSide { get; set; }
        string BallastForward { get; set; }
        string CrossWeight { get; set; }
        string FrontBrakeBias { get; set; }
        string LeftBarEndClearance { get; set; }
        string NoseWeight { get; set; }
        string SteeringOffset { get; set; }
        string SteeringRatio { get; set; }
        string SwayBarArmLength { get; set; }
        string SwayBarSize { get; set; }
        string ToeIn { get; set; }
    }
}