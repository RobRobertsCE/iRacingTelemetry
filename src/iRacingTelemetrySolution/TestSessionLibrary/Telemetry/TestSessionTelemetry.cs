using ibtParserLibrary;

namespace TestSessionLibrary.Telemetry
{
    public class TestSessionTelemetry
    {
        ParserEngine _parser;

        public TelemetrySession Session { get; private set; }

        public TestSessionTelemetry()
        {
            _parser = new ParserEngine();
        }

        public virtual void ParseTelemetryFile(string fileName, byte[] teletryFileBytes)
        {
            Session = _parser.ParseTelemetryBytes(fileName, teletryFileBytes);
        }
    }
}
