namespace iRacing.SetupLibrary
{
    public interface ISetupTires
    {
        ILeftFrontTire LeftFront { get;}
        ILeftRearTire LeftRear { get;}
        IRightFrontTire RightFront { get; }
        IRightRearTire RightRear { get; }
    }
}