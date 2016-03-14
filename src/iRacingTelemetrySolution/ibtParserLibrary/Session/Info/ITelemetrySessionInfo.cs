using ibtParserLibrary.Session.Cars;

namespace ibtParserLibrary.Session.Info
{
    public interface ITelemetrySessionInfo
    {
        CameraInfo CameraInfo { get; set; }
        DriverInfo DriverInfo { get; set; }
        RadioInfo RadioInfo { get; set; }
        SessionInfo SessionInfo { get; set; }
        SplitTimeInfo SplitTimeInfo { get; set; }
        WeekendInfo WeekendInfo { get; set; }
    }
}