using iRacing.TrackSession.Views;

namespace TrackSession.Controls
{
    public interface ITrackSessionRunDisplay
    {
        bool IsActive { get; set; }
        void DisplayRun(TrackSessionRunView runView);
        void DisplaySession(TrackSessionView runView);
        void DisplayTireSheet();
        void Clear();
    }
}
