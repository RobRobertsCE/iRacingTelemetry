using ibtSessionLibrary.Info;
using iRacing.SetupLibrary;

namespace ibtSessionLibrary
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
        //ICarSetup Setup { get; set; }
    }
}