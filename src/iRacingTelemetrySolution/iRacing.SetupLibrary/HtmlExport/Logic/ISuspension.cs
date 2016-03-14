namespace SetupExportParser.Logic
{
    public interface ISuspension
    {
        int Weight { get; set; }
        double Height { get; set; }
        double ScrewJack { get; set; }
        int SpringRate { get; set; }
        int BumpStiffness { get; set; }
        int ReboundStiffness { get; set; }
    }
}
