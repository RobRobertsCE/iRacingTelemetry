using ibtParserLibrary.Session.Cars;
using ibtParserLibrary.Session.Info;
using iRacing;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ibtParserLibrary.Session
{
    public static class TelemetrySessionInfoFactory
    {
        public static TelemetrySessionInfo GetSessionInfo(string yamlString)
        {
            var yamlObject = GetYamlObject(yamlString);
            var jsonString = YamlToJson(yamlObject);
            var sessionInfo = GetTelemetrySessionInfo(jsonString);

            var myIdx = Convert.ToInt32(sessionInfo.DriverInfo.DriverCarIdx);
            var me = sessionInfo.DriverInfo.Drivers[myIdx];

            var infoView = new SetupInfoView()
            {
                DriverID = Convert.ToInt32(me.UserID),
                DriverName = me.UserName,
                CarID = Convert.ToInt32(me.CarID),
                CarClassID = Convert.ToInt32(me.CarClassID),
                CarPath = me.CarPath,
                CarClassShortName = me.CarClassShortName,
                CarScreenName = me.CarScreenName,
                TrackID = Convert.ToInt32(sessionInfo.WeekendInfo.TrackID),
                TrackName = sessionInfo.WeekendInfo.TrackName,
                JsonData = jsonString
            };

            sessionInfo= GetSessionSetupInfo(infoView);

            return sessionInfo;
        }

        public static TelemetrySessionInfo GetSessionSetupInfo(SetupInfoView infoView)
        {
            Vehicles car = (Vehicles)infoView.CarID;
            switch (car)
            {
                case Vehicles.legends:
                    {
                        return GetTelemetrySessionInfo<LegendsTelemetryData>(infoView.JsonData);
                    }
                case Vehicles.streetstock:
                    {
                        return GetTelemetrySessionInfo<SSTelemetryData>(infoView.JsonData);
                    }
                case Vehicles.latemodel:
                    {
                        return GetTelemetrySessionInfo<LMSCTelemetryData>(infoView.JsonData);
                    }
                case Vehicles.kandnseries:
                    {
                        return GetTelemetrySessionInfo<KNTelemetryData>(infoView.JsonData);
                    }
                case Vehicles.superlatemodel:
                    {
                        return GetTelemetrySessionInfo<SLMTelemetryData>(infoView.JsonData);
                    }
                case Vehicles.skmodified:
                    {
                        return GetTelemetrySessionInfo<ModifiedTelemetryData>(infoView.JsonData);
                    }
                case Vehicles.tourmodified:
                    {
                        return GetTelemetrySessionInfo<ModifiedTelemetryData>(infoView.JsonData);
                    }
                case Vehicles.silverado2015:
                    {
                        return GetTelemetrySessionInfo<TruckTelemetryData>(infoView.JsonData);
                    }
                case Vehicles.xfinityFordMustang:
                    {
                        return GetTelemetrySessionInfo<XfinityTelemetryData>(infoView.JsonData);
                    }
                case Vehicles.gen6FordFusion:
                    {
                        return GetTelemetrySessionInfo<CupTelemetryData>(infoView.JsonData);
                    }
                default:
                    {
                        var errorMessage = String.Format("New Car - CarId:{0} CarClassID:{1} CarClassShortName:{2} CarPath:{3} CarScreenName:{4}", infoView.CarID.ToString(), infoView.CarClassID.ToString(), infoView.CarClassShortName, infoView.CarPath, infoView.CarScreenName);
                        Console.WriteLine(errorMessage);
                        break;
                    }
            }
            return null;
        }
        private static object GetYamlObject(string yamlString)
        {
            using (var yamlStream = ConvertStringToStream(yamlString))
            {
                using (var yamlStreamReader = new StreamReader(yamlStream))
                {
                    var yamlDeserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());
                    return yamlDeserializer.Deserialize(yamlStreamReader);
                }
            }
        }
        private static Stream ConvertStringToStream(string yamlString)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(yamlString);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
        private static string YamlToJson(object yamlObject)
        {
            JsonSerializer jsonSerializer = new JsonSerializer() { Formatting = Formatting.Indented };
            using (var jsonStreamWriter = new StringWriter())
            {
                jsonSerializer.Serialize(jsonStreamWriter, yamlObject);
                return jsonStreamWriter.ToString();
            }
        }
        private static TelemetrySessionInfo GetTelemetrySessionInfo(string jsonString)
        {
            return JsonConvert.DeserializeObject<TelemetrySessionInfo>(jsonString);
        }
        private static T GetTelemetrySessionInfo<T>(string jsonString)
        {
            var result = JsonConvert.DeserializeObject(jsonString, typeof(T),
                                                       new JsonSerializerSettings()
                                                       { TypeNameHandling = TypeNameHandling.All });
            return (T)result;
            //return JsonConvert.DeserializeObject<T>(jsonString);
        }
        private static ISetupTelemetryData GetSetupTelemetryData<T>(string jsonString)
        {
            var token = "CarSetup";
            var startIdx = jsonString.IndexOf(token) - 1;
            var setupJsonLength = jsonString.Length - startIdx;
            var setupJson = "{" + jsonString.Substring(startIdx, setupJsonLength);
            var result = JsonConvert.DeserializeObject(setupJson, typeof(T),
                                                       new JsonSerializerSettings()
                                                       { TypeNameHandling = TypeNameHandling.All });
            return (ISetupTelemetryData)result;
            //return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
