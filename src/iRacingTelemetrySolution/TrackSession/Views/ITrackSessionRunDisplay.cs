using TestSessionLibrary.Views;

namespace TrackSession.Views
{
    public interface ITrackSessionRunDisplay
    {
        bool IsActive { get; set; }
        void DisplayRun(TrackSessionRunView runView);
    }
}
