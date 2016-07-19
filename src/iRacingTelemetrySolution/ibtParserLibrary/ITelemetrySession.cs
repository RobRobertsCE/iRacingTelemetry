using System;
using System.Collections.Generic;
using iRacing.TelemetryParser.Session;

namespace iRacing.TelemetryParser
{
    public interface ITelemetrySession
    {
        IList<TelemetryChannelDefinition> Fields { get; set; }
        string FileName { get; set; }
        IList<TelemetryFrame> Frames { get; set; }
        TelemetryLapList Laps { get; set; }
        ITelemetrySessionInfo SessionInfo { get; set; }
        DateTime Timestamp { get; set; }

        string FieldsToString();
        string ToString();
        string ValuesToString();
    }
}