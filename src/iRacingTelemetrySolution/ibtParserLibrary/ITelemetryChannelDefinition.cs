namespace iRacing.TelemetryParser
{
    public interface ITelemetryChannelDefinition
    {
        int DataType { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        int Position { get; set; }
        int Size { get; }
        string Unit { get; set; }

        string ToString();
    }
}