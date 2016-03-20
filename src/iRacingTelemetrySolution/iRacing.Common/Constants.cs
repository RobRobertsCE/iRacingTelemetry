using System.Collections.Generic;

namespace iRacing
{
    public static class Constants
    {
        public const string iRacingSetupDirectory = @"C:\Users\rroberts\Documents\iRacing\setups";
        public const string iRacingDefaultSetupFile = @"-Current-";  
        public const string iRacingTelemetryDirectory = @"C:\Users\rroberts\Documents\iRacing\telemetry";
        public const string iRacingSetupExportFileFilter = "*.htm";
        public const string iRacingTelemetryFileFilter = "*.ibt";
        public const string iRacingDX9ProcessName = "iRacingSim64";
        public const string iRacingDX11ProcessName = "iRacingSim64DX11";
        public const string iRacingCarPathToken = "{CarPath}";
        public const string SetupGroupTires_LeftFront = "Tires.LeftFront";
        public const string SetupGroupTires_RightFront = "Tires.RightFront";
        public const string SetupGroupTires_LeftRear = "Tires.LeftRear";
        public const string SetupGroupTires_RightRear = "Tires.RightRear";
        public const string SetupGroupChassis_LeftFront = "Chassis.LeftFront";
        public const string SetupGroupChassis_RightFront = "Chassis.RightFront";
        public const string SetupGroupChassis_LeftRear = "Chassis.LeftRear";
        public const string SetupGroupChassis_RightRear = "Chassis.RightRear";
        public const string SetupGroupChassis_Front = "Chassis.Front";
        public const string SetupGroupChassis_Rear = "Chassis.Rear";
        public const string SetupGroupChassis_FrontARB = "Chassis.FrontARB";
        public static readonly string[] SetupGroupList = {
                SetupGroupTires_LeftFront,
                SetupGroupTires_RightFront,
                SetupGroupTires_LeftRear,
                SetupGroupTires_RightRear,
                SetupGroupChassis_LeftFront,
                SetupGroupChassis_RightFront,
                SetupGroupChassis_LeftRear,
                SetupGroupChassis_RightRear,
                SetupGroupChassis_Front,
                SetupGroupChassis_Rear,
                SetupGroupChassis_FrontARB
        };
    }
}
