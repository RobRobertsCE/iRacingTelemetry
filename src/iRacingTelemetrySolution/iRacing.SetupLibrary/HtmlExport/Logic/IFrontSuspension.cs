namespace SetupExportParser.Logic
{
    public interface IFrontSuspension : ISuspension
    {
        double Caster { get; set; }
        double Camber { get; set; }
    }
}
