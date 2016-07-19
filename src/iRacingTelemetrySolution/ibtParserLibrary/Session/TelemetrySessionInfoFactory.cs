using iRacing.TelemetryParser.Session.Info;
using iRacing.TelemetryParser.Session.CarSetup;
using iRacing;
using iRacing.SetupLibrary.Parsers;
using Newtonsoft.Json;
using System;
using iRacing.SetupLibrary;
using Newtonsoft.Json.Linq;

namespace iRacing.TelemetryParser.Session
{
    public static class TelemetrySessionInfoFactory
    {
        #region properties
        private static JsonSerializerSettings _settings = null;
        public static JsonSerializerSettings Settings
        {
            get
            {
                if (null == _settings)
                {
                    _settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        Formatting = Formatting.Indented
                    };
                }
                return _settings;
            }
        }
        #endregion

        #region public
        /// <summary>
        /// Parses the ibt-based Session Info YAML string
        /// </summary>
        /// <param name="yamlString">YAML-formatted string containing the session info for the telemetry file</param>
        /// <returns>Car-specific instance of the TelemetrySessionInfo class.</returns>
        public static TelemetrySessionInfo GetSessionInfo(string yamlString)
        {
            var jsonString = YamlSetupParser.GetJson(yamlString);
            return GetTelemetrySessionInfo(jsonString);
        }
        #endregion

        #region private
        /// <summary>
        /// Gets the session info *except for* setup data.
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        private static TelemetrySessionInfo GetTelemetrySessionInfo(string jsonString)
        {
            return JsonConvert.DeserializeObject<TelemetrySessionInfo>(jsonString, Settings);
        }
        #endregion
    }
}
