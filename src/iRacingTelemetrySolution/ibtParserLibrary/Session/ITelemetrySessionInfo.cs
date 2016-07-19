﻿using iRacing.SetupLibrary;
using iRacing.TelemetryParser.Session.Info;

namespace iRacing.TelemetryParser.Session
{
    public interface ITelemetrySessionInfo
    {
        CameraInfo CameraInfo { get; set; }
        DriverInfo DriverInfo { get; set; }
        RadioInfo RadioInfo { get; set; }
        SessionInfo SessionInfo { get; set; }
        SplitTimeInfo SplitTimeInfo { get; set; }
        WeekendInfo WeekendInfo { get; set; }
        ICompositeSetup CarSetup { get; set; }
        string SetupJSON { get; set; }
    }
}