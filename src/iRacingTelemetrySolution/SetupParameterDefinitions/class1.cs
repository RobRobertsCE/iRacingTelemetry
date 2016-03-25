using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupParameterDefinitions
{
    public interface ISKModifiedSetup
    {
        ISKModifiedSetupTires Tires { get; set; }
        ISKModifiedSetupChassis Chassis { get; set; }
    }

    public interface ISKModifiedSetupTires
    {
        ISKModifiedSetupTiresLeftFront LF { get; set; }
        ISKModifiedSetupTiresRightFront RF { get; set; }
        ISKModifiedSetupTiresLeftRear LR { get; set; }
        ISKModifiedSetupTiresRightRear RR { get; set; }
    }
    public interface ISKModifiedSetupTiresLeftFront
    {
        string ColdPressure { get; set; }
        string LastHotPressure { get; set; }
        string LastTempsOMI { get; set; }
        string TreadRemaining { get; set; }
    }
    public interface ISKModifiedSetupTiresRightFront
    {
        string ColdPressure { get; set; }
        string LastHotPressure { get; set; }
        string LastTempsIMO { get; set; }
        string TreadRemaining { get; set; }
        string Stagger { get; set; }
    }
    public interface ISKModifiedSetupTiresLeftRear
    {
        string ColdPressure { get; set; }
        string LastHotPressure { get; set; }
        string LastTempsOMI { get; set; }
        string TreadRemaining { get; set; }
    }
    public interface ISKModifiedSetupTiresRightRear
    {
        string ColdPressure { get; set; }
        string LastHotPressure { get; set; }
        string LastTempsIMO { get; set; }
        string TreadRemaining { get; set; }
        string Stagger { get; set; }
    }

    public interface ISKModifiedSetupChassis
    {
        ISKModifiedSetupChassisFront Front { get; set; }
        ISKModifiedSetupChassisLeftFront LeftFront { get; set; }
        ISKModifiedSetupChassisRightFront RightFront { get; set; }
        ISKModifiedSetupChassisLeftRear LeftRear { get; set; }
        ISKModifiedSetupChassisRightRear RightRear { get; set; }
        ISKModifiedSetupChassisRear Rear { get; set; }
    }
    public interface ISKModifiedSetupChassisFront
    {
        string BallastForward { get; set; }
        string NoseWeight { get; set; }
        string CrossWeight { get; set; }
        string ToeIn { get; set; }
        string SteeringRatio { get; set; }
        string SteeringOffset { get; set; }
        string FrontBrakeBias { get; set; }
        string SwayBarSize { get; set; }
        string SwayBarArmLength { get; set; }
        string LeftBarEndClearance { get; set; }
        string AttachLeftSide { get; set; }
    }
    public interface ISKModifiedSetupChassisLeftFront
    {
        string CornerWeight { get; set; }
        string RideHeight { get; set; }
        string SpringRate { get; set; }
        string BumpStiffness { get; set; }
        string ReboundStiffness { get; set; }
        string ShockCollarOffset { get; set; }
        string Camber { get; set; }
        string Caster { get; set; }
    }
    public interface ISKModifiedSetupChassisRightFront
    {
        string CornerWeight { get; set; }
        string RideHeight { get; set; }
        string SpringRate { get; set; }
        string BumpStiffness { get; set; }
        string ReboundStiffness { get; set; }
        string ShockCollarOffset { get; set; }
        string Camber { get; set; }
        string Caster { get; set; }
    }
    public interface ISKModifiedSetupChassisLeftRear
    {
        string CornerWeight { get; set; }
        string RideHeight { get; set; }
        string SpringRate { get; set; }
        string ShockCollarOffset { get; set; }
        string BumpStiffness { get; set; }
        string ReboundStiffness { get; set; }
        string TrackBarHeight { get; set; }
    }
    public interface ISKModifiedSetupChassisRightRear
    {
        string CornerWeight { get; set; }
        string RideHeight { get; set; }
        string SpringRate { get; set; }
        string ShockCollarOffset { get; set; }
        string BumpStiffness { get; set; }
        string ReboundStiffness { get; set; }
        string TrackBarHeight { get; set; }
    }
    public interface ISKModifiedSetupChassisRear
    {
        string RearEndRatio { get; set; }
        string FuelFillTo { get; set; }
    }    
}