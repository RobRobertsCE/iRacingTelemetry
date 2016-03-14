using ibtParserLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestSessionLibrary.Telemetry
{
    public class TestSessionYamlParser
    {
        public static void ParseSessionYaml(TestSessionRun run, TelemetrySession session)
        {
            var yamlLines = session.Yaml.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            run.TrackName = FindValue("TrackDisplayName", yamlLines);
            run.TrackIdNumber = FindValue("TrackID", yamlLines);
            run.CarName = FindValue("CarClassShortName", yamlLines);
            run.CarPath = FindValue("CarPath", yamlLines);
            run.CarIdNumber = FindValue("SeriesID", yamlLines);
            run.TrackTemp = FindValue("TrackSurfaceTemp", yamlLines);
            run.AirTemp = FindValue("TrackAirTemp", yamlLines);
            run.Skies = FindValue("TrackSkies", yamlLines);
            run.Night = (FindValue("NightMode", yamlLines) == "1");
            run.TelemetryDiskFile = FindValue("TelemetryDiskFile", yamlLines);
            run.SessionType = FindValue("SessionType", yamlLines);
            run.SetupName = FindValue("SetupName", yamlLines);
            run.SetupIsModified = (FindValue("SetupIsModified", yamlLines) =="1");
        }

        private static string FindValue(string key, IList<string> yamlLines)
        {
            var line = yamlLines.FirstOrDefault(l => l.Contains(key));
            if (null != line)
                return line.Split(':')[1].Trim();
            else
                return String.Empty;
        }
    }
}
