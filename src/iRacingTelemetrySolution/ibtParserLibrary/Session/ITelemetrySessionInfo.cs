using ibtParserLibrary.Session.Info;

namespace ibtParserLibrary.Session
{
    public interface ITelemetrySessionInfo
    {
        CameraInfo CameraInfo { get; set; }
        DriverInfo DriverInfo { get; set; }
        RadioInfo RadioInfo { get; set; }
        SessionInfo SessionInfo { get; set; }
        SplitTimeInfo SplitTimeInfo { get; set; }
        WeekendInfo WeekendInfo { get; set; }
        string SetupJSON { get; set; }
    }
}