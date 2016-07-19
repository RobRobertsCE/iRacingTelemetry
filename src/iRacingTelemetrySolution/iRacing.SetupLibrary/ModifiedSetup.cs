using System;
using Newtonsoft.Json;

namespace iRacing.SetupLibrary
{
    public partial class ModifiedSetup : SetupBase, ICarSetup, ICompositeSetup
    {
        #region properties
        [JsonProperty("UpdateCount")]
        public int UpdateCount { get; set; }
        [JsonProperty("Tires")]
        public SetupTires Tires { get; set; }
        [JsonProperty("Chassis")]
        public SetupChassis Chassis { get; set; }
        #endregion

        #region ICompositeSetup support
        [JsonIgnore()]
        ISetupChassis ICompositeSetup.Chassis
        {
            get
            {
                return (ISetupChassis)Chassis;
            }
        }

        [JsonIgnore()]
        ISetupTires ICompositeSetup.Tires
        {
            get
            {
                return (ISetupTires)Tires;
            }
        }
        #endregion

        #region classes
        public class SetupChassis : ISetupChassis
        {
            #region properties
            [JsonProperty("Front")]
            public ChassisFront Front { get; set; }
            [JsonProperty("LeftFront")]
            public ChassisLeftFront LeftFront { get; set; }
            [JsonProperty("LeftRear")]
            public ChassisLeftRear LeftRear { get; set; }
            [JsonProperty("RightFront")]
            public ChassisRightFront RightFront { get; set; }
            [JsonProperty("RightRear")]
            public ChassisRightRear RightRear { get; set; }
            [JsonProperty("Rear")]
            public ChassisRear Rear { get; set; }
            #endregion

            #region ICompositeSetup support
            [JsonIgnore()]
            IChassisFront ISetupChassis.Front
            {
                get
                {
                    return (IChassisFront)Front;
                }
            }
            [JsonIgnore()]
            IChassisLeftFront ISetupChassis.LeftFront
            {
                get
                {
                    return (IChassisLeftFront)LeftFront;
                }
            }
            [JsonIgnore()]
            IChassisLeftRear ISetupChassis.LeftRear
            {
                get
                {
                    return (IChassisLeftRear)LeftRear;
                }
            }
            [JsonIgnore()]
            IChassisRear ISetupChassis.Rear
            {
                get
                {
                    return (IChassisRear)Rear;
                }
            }
            [JsonIgnore()]
            IChassisRightFront ISetupChassis.RightFront
            {
                get
                {
                    return (IChassisRightFront)RightFront;
                }
            }
            [JsonIgnore()]
            IChassisRightRear ISetupChassis.RightRear
            {
                get
                {
                    return (IChassisRightRear)RightRear;
                }
            }
            #endregion

            #region classes
            public class ChassisFront : IChassisFront
            {
                [JsonProperty("BallastForward")]
                public string BallastForward { get; set; }
                [JsonProperty("NoseWeight")]
                public string NoseWeight { get; set; }
                [JsonProperty("CrossWeight")]
                public string CrossWeight { get; set; }
                [JsonProperty("ToeIn")]
                public string ToeIn { get; set; }
                [JsonProperty("SteeringRatio")]
                public string SteeringRatio { get; set; }
                [JsonProperty("SteeringOffset")]
                public string SteeringOffset { get; set; }
                [JsonProperty("FrontBrakeBias")]
                public string FrontBrakeBias { get; set; }
                [JsonProperty("SwayBarSize")]
                public string SwayBarSize { get; set; }
                [JsonProperty("SwayBarArmLength")]
                public string SwayBarArmLength { get; set; }
                [JsonProperty("LeftBarEndClearance")]
                public string LeftBarEndClearance { get; set; }
                [JsonProperty("AttachLeftSide")]
                public string AttachLeftSide { get; set; }
            }
            public class ChassisLeftFront : IChassisLeftFront
            {
                [JsonProperty("CornerWeight")]
                public string CornerWeight { get; set; }
                [JsonProperty("RideHeight")]
                public string RideHeight { get; set; }
                [JsonProperty("SpringRate")]
                public string SpringRate { get; set; }
                [JsonProperty("BumpStiffness")]
                public string BumpStiffness { get; set; }
                [JsonProperty("ReboundStiffness")]
                public string ReboundStiffness { get; set; }
                [JsonProperty("ShockCollarOffset")]
                public string ShockCollarOffset { get; set; }
                [JsonProperty("Camber")]
                public string Camber { get; set; }
                [JsonProperty("Caster")]
                public string Caster { get; set; }
            }
            public class ChassisLeftRear : IChassisLeftRear
            {
                [JsonProperty("CornerWeight")]
                public string CornerWeight { get; set; }
                [JsonProperty("RideHeight")]
                public string RideHeight { get; set; }
                [JsonProperty("SpringRate")]
                public string SpringRate { get; set; }
                [JsonProperty("ShockCollarOffset")]
                public string ShockCollarOffset { get; set; }
                [JsonProperty("BumpStiffness")]
                public string BumpStiffness { get; set; }
                [JsonProperty("ReboundStiffness")]
                public string ReboundStiffness { get; set; }
                [JsonProperty("TrackBarHeight")]
                public string TrackBarHeight { get; set; }
            }
            public class ChassisRightFront : IChassisRightFront
            {
                [JsonProperty("CornerWeight")]
                public string CornerWeight { get; set; }
                [JsonProperty("RideHeight")]
                public string RideHeight { get; set; }
                [JsonProperty("SpringRate")]
                public string SpringRate { get; set; }
                [JsonProperty("BumpStiffness")]
                public string BumpStiffness { get; set; }
                [JsonProperty("ReboundStiffness")]
                public string ReboundStiffness { get; set; }
                [JsonProperty("ShockCollarOffset")]
                public string ShockCollarOffset { get; set; }
                [JsonProperty("Camber")]
                public string Camber { get; set; }
                [JsonProperty("Caster")]
                public string Caster { get; set; }
            }
            public class ChassisRightRear : IChassisRightRear
            {
                [JsonProperty("CornerWeight")]
                public string CornerWeight { get; set; }
                [JsonProperty("RideHeight")]
                public string RideHeight { get; set; }
                [JsonProperty("SpringRate")]
                public string SpringRate { get; set; }
                [JsonProperty("ShockCollarOffset")]
                public string ShockCollarOffset { get; set; }
                [JsonProperty("BumpStiffness")]
                public string BumpStiffness { get; set; }
                [JsonProperty("ReboundStiffness")]
                public string ReboundStiffness { get; set; }
                [JsonProperty("TrackBarHeight")]
                public string TrackBarHeight { get; set; }
            }
            public class ChassisRear : IChassisRear
            {
                [JsonProperty("RearEndRatio")]
                public string RearEndRatio { get; set; }
                [JsonProperty("FuelFillTo")]
                public string FuelFillTo { get; set; }
            }
            #endregion
        }

        public class SetupTires : ISetupTires
        {
            #region properties
            [JsonProperty("LeftFront")]
            public TiresLeftFront LeftFront { get; set; }
            [JsonProperty("LeftRear")]
            public TiresLeftRear LeftRear { get; set; }
            [JsonProperty("RightFront")]
            public TiresRightFront RightFront { get; set; }
            [JsonProperty("RightRear")]
            public TiresRightRear RightRear { get; set; }
            #endregion

            #region ICompositeSetup support       
            [JsonIgnore()]
            ILeftFrontTire ISetupTires.LeftFront
            {
                get
                {
                    return (ILeftFrontTire)LeftFront;
                }
            }
            [JsonIgnore()]
            ILeftRearTire ISetupTires.LeftRear
            {
                get
                {
                    return (ILeftRearTire)LeftRear;
                }
            }
            [JsonIgnore()]
            IRightFrontTire ISetupTires.RightFront
            {
                get
                {
                    return (IRightFrontTire)RightFront;
                }
            }
            [JsonIgnore()]
            IRightRearTire ISetupTires.RightRear
            {
                get
                {
                    return (IRightRearTire)RightRear;
                }
            }
            #endregion

            #region classes
            public class TiresLeftFront : ILeftFrontTire
            {
                [JsonProperty("ColdPressure")]
                public string ColdPressure { get; set; }
                [JsonProperty("LastHotPressure")]
                public string LastHotPressure { get; set; }
                [JsonProperty("LastTempsOMI")]
                public string LastTempsOMI { get; set; }
                [JsonProperty("TreadRemaining")]
                public string TreadRemaining { get; set; }
            }
            public class TiresLeftRear : ILeftRearTire
            {
                [JsonProperty("ColdPressure")]
                public string ColdPressure { get; set; }
                [JsonProperty("LastHotPressure")]
                public string LastHotPressure { get; set; }
                [JsonProperty("LastTempsOMI")]
                public string LastTempsOMI { get; set; }
                [JsonProperty("TreadRemaining")]
                public string TreadRemaining { get; set; }
            }
            public class TiresRightFront : IRightFrontTire
            {
                [JsonProperty("ColdPressure")]
                public string ColdPressure { get; set; }
                [JsonProperty("LastHotPressure")]
                public string LastHotPressure { get; set; }
                [JsonProperty("LastTempsIMO")]
                public string LastTempsIMO { get; set; }
                [JsonProperty("TreadRemaining")]
                public string TreadRemaining { get; set; }
                [JsonProperty("Stagger")]
                public string Stagger { get; set; }
            }
            public class TiresRightRear : IRightRearTire
            {
                [JsonProperty("ColdPressure")]
                public string ColdPressure { get; set; }
                [JsonProperty("LastHotPressure")]
                public string LastHotPressure { get; set; }
                [JsonProperty("LastTempsIMO")]
                public string LastTempsIMO { get; set; }
                [JsonProperty("TreadRemaining")]
                public string TreadRemaining { get; set; }
                [JsonProperty("Stagger")]
                public string Stagger { get; set; }
            }
            #endregion
        }
        #endregion
    }
}
