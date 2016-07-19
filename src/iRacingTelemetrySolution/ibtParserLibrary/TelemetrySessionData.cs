namespace iRacing.TelemetryParser
{
    internal class TelemetrySessionData
    {
        public string Yaml { get; set; }
        public byte[] RawHeader { get; set; }
        public byte[] RawYaml { get; set; }
        public byte[] RawFrames { get; set; }
    }
}
