using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.SetupLibrary.Composite
{
    public class CompositeSetup
    {
        public class CompositeTires
        {
            public SetupTireLeft LF { get; set; }
            public SetupTireLeft LR { get; set; }
            public SetupTireRight RF { get; set; }
            public SetupTireRight RR { get; set; }
        }

        public class CompositeChassis
        {
            public ChassisFront Front { get; set; }
            public ChassisFrontARB FrontARB { get; set; }
            public ChassisFrontSuspension LF { get; set; }
            public ChassisRearSuspension LR { get; set; }
            public ChassisFrontSuspension RF { get; set; }
            public ChassisRearSuspension RR { get; set; }
            public ChassisRear Rear { get; set; }
        }
    }
    
    public class SetupTireLeft
    {
        public string ColdPressure { get; set; }
        public string LastHotPressure { get; set; }
        public string LastTempsOMI { get; set; }
        public string TreadRemaining { get; set; }
    }
    public class SetupTireRight
    {
        public string ColdPressure { get; set; }
        public string LastHotPressure { get; set; }
        public string LastTempsIMO { get; set; }
        public string TreadRemaining { get; set; }
        public string Stagger { get; set; }
    }

    public class ChassisFront
    {
        public string BallastForward { get; set; }
        public string NoseWeight { get; set; }
        public string CrossWeight { get; set; }
        public string ToeIn { get; set; }
        public string SteeringRatio { get; set; }
        public string SteeringOffset { get; set; }
        public string FrontBrakeBias { get; set; }
        public string BrakeBalanceBar { get; set; }
        public string SwayBarSize { get; set; }
        public string SwayBarArmLength { get; set; }
        public string LeftBarEndClearance { get; set; }
        public string AttachLeftSide { get; set; }
        public string SkirtClearance { get; set; }
        public string FrontWheelOffset { get; set; }
        public string TapeConfiguration { get; set; }
    }

    public class ChassisRear
    {
        public string RearEndRatio { get; set; }
        public string FuelLevel { get; set; }
        public string FuelFillTo { get; set; }
        public string CrossWeight { get; set; }
        public string ArbDiameter { get; set; }
        public string ArmAsymmetry { get; set; }
        public string ChainOrSolidLink { get; set; }
        public string Preload { get; set; }
        public string Attach { get; set; }
        public string LinkSlack { get; set; }
    }

    public class ChassisFrontSuspension
    {
        public string CornerWeight { get; set; }
        public string RideHeight { get; set; }
        public string SpringDeflection { get; set; }
        public string SpringPerchOffset { get; set; }
        public string SpringRate { get; set; }
        public string SpringPerch { get; set; }
        public string BumpStiffness { get; set; }
        public string ReboundStiffness { get; set; }
        public string ShockCompression { get; set; }
        public string ShockRebound { get; set; }
        public string ShockDeflection { get; set; }
        public string ShockCollarOffset { get; set; }
        public string Packer { get; set; }
        public string ShockSpringRate { get; set; }
        public string Camber { get; set; }
        public string Caster { get; set; }
        public string ToeIn { get; set; }
        public string SkirtClearance { get; set; }
    }

    public class ChassisRearSuspension
    {
        public string CornerWeight { get; set; }
        public string RideHeight { get; set; }
        public string SpringDeflection { get; set; }
        public string SpringPerchOffset { get; set; }
        public string SpringRate { get; set; }
        public string LeafSpringRate { get; set; }
        public string LeafArchBlock { get; set; }
        public string Packer { get; set; }
        public string ShockCollarOffset { get; set; }
        public string ShockDeflection { get; set; }
        public string BumpStiffness { get; set; }
        public string ReboundStiffness { get; set; }
        public string ShockCompression { get; set; }
        public string ShockRebound { get; set; }
        public string LeftRearToeIn { get; set; }
        public string ToeIn { get; set; }
        public string Camber { get; set; }
        public string TruckArmMount { get; set; }
        public string TrailingArmMount { get; set; }
        public string TrackBarHeight { get; set; }
        public string SkirtClearance { get; set; }
    }

    public class ChassisFrontARB
    {
        public string RearEndRatio { get; set; }
        public string FuelLevel { get; set; }
        public string FuelFillTo { get; set; }
        public string CrossWeight { get; set; }
        public string ArbDiameter { get; set; }
        public string ArmAsymmetry { get; set; }
        public string ChainOrSolidLink { get; set; }
        public string Preload { get; set; }
        public string Attach { get; set; }
        public string LinkSlack { get; set; }
    }
}

