using System;

namespace SetupExportParser.Logic
{
    public interface ISetup
    {
        Guid SetupId { get; set; }
        string Name { get; set; }
        string TrackName { get; set; }
        string CarName { get; set; }
        IFrontSuspension LFSuspension { get; set; }
        IFrontSuspension RFSuspension { get; set; }
        IRearSuspension LRSuspension { get; set; }
        IRearSuspension RRSuspension { get; set; }
        ITire LFTire { get; set; }
        ITire RFTire { get; set; }
        ITire LRTire { get; set; }
        ITire RRTire { get; set; }
        int BallastForward { get; set; }
        double FrontWeightPercent { get; set; }
        double CrossWeightPercent { get; set; }
        double ToeIn { get; set; }
        int SteerRatio { get; set; }
        double SteerOffset { get; set; }
        double FtBrakeBias { get; set; }
        double SwayBarSize { get; set; }
        int SwayBarArm { get; set; }
        double SwayBarLeftClearance { get; set; }
        bool SwayBarLeftAttached { get; set; }
        double FuelLevel { get; set; }
        double FinalGearRatio { get; set; }
        string Notes { get; set; }
        int TotalWeight { get; }
        int LeftSideWeight { get; }
        int RightSideWeight { get; }
        int RearWeight { get; }
        int FrontWeight { get; }
        int CrossWeight { get; }
        double LeftWeightPercent { get; }
        double FrontSpringSplit { get; }
        double RearSpringSplit { get; }
        double FrontHeightSplit { get; }
        double RearHeightSplit { get; }
        double Rake { get; }
        double Lean { get; }
        double TrackBarSplit { get; }
        double CamberSplit { get; }
        double CasterSplit { get; }
        double ConvertFractionToDouble(string data);
        string CleanInput(string data);
    }
}
