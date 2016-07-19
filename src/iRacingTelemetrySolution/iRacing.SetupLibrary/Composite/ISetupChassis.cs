namespace iRacing.SetupLibrary
{
    public interface ISetupChassis
    {
        IChassisFront Front { get; }
        IChassisLeftFront LeftFront { get; }
        IChassisLeftRear LeftRear { get; }
        IChassisRear Rear { get; }
        IChassisRightFront RightFront { get; }
        IChassisRightRear RightRear { get; }
    }
}