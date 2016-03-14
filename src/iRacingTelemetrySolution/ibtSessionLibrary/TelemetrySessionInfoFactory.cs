using ibtSessionLibrary.CarSetup;
using ibtSessionLibrary.Info;
using iRacing;
using iRacing.SetupLibrary.Parsers;
using Newtonsoft.Json;
using System;

namespace ibtSessionLibrary
{
    public static class TelemetrySessionInfoFactory
    {
        /// <summary>
        /// Parses the ibt-based Session Info YAML string
        /// </summary>
        /// <param name="yamlString">YAML-formatted string containing the session info for the telemetry file</param>
        /// <returns>Car-specific instance of the TelemetrySessionInfo class.</returns>
        public static TelemetrySessionInfo GetSessionInfo(string yamlString)
        {
            var jsonString = YamlSetupParser.GetJson(yamlString);
            var genericSessionInfo = GetTelemetrySessionInfo(jsonString);
            var driverIdx = Convert.ToInt32(genericSessionInfo.DriverInfo.DriverCarIdx);
            var driver = genericSessionInfo.DriverInfo.Drivers[driverIdx];

            var infoView = new SetupInfoView()
            {
                DriverID = Convert.ToInt32(driver.UserID),
                DriverName = driver.UserName,
                CarID = Convert.ToInt32(driver.CarID),
                CarClassID = Convert.ToInt32(driver.CarClassID),
                CarPath = driver.CarPath,
                CarClassShortName = driver.CarClassShortName,
                CarScreenName = driver.CarScreenName,
                TrackID = Convert.ToInt32(genericSessionInfo.WeekendInfo.TrackID),
                TrackName = genericSessionInfo.WeekendInfo.TrackName,
                JsonData = jsonString
            };

            genericSessionInfo= GetSessionSetupInfo(infoView);

            return genericSessionInfo;
        }
        /// <summary>
        /// Gets the session info including car-specific setup data.
        /// </summary>
        /// <param name="infoView">SetupInfoView class instance containing JSON data</param>
        /// <returns></returns>
        private static TelemetrySessionInfo GetSessionSetupInfo(SetupInfoView infoView)
        {
            TelemetrySessionInfo session = null;
            Vehicles car = (Vehicles)infoView.CarID;
            switch (car)
            {
                case Vehicles.legends:
                    {
                        session = GetTelemetrySessionInfo<LegendsTelemetrySessionInfo>(infoView.JsonData);
                        break;
                    }
                case Vehicles.streetstock:
                    {
                        session = GetTelemetrySessionInfo<SSTelemetrySessionInfo>(infoView.JsonData);
                        break;
                    }
                case Vehicles.latemodel:
                    {
                        session = GetTelemetrySessionInfo<LMSCTelemetrySessionInfo>(infoView.JsonData);
                        break;
                    }
                case Vehicles.kandnseries:
                    {
                        session = GetTelemetrySessionInfo<KNTelemetrySessionInfo>(infoView.JsonData);
                        break;
                    }
                case Vehicles.superlatemodel:
                    {
                        session = GetTelemetrySessionInfo<SLMTelemetrySessionInfo>(infoView.JsonData);
                        break;
                    }
                case Vehicles.skmodified:
                    {
                        session = GetTelemetrySessionInfo<ModifiedTelemetrySessionInfo>(infoView.JsonData);
                        break;
                    }
                case Vehicles.tourmodified:
                    {
                        session = GetTelemetrySessionInfo<ModifiedTelemetrySessionInfo>(infoView.JsonData);
                        break;
                    }
                case Vehicles.silverado2015:
                    {
                        session = GetTelemetrySessionInfo<TruckTelemetrySessionInfo>(infoView.JsonData);
                        break;
                    }
                case Vehicles.xfinityFordMustang:
                    {
                        session = GetTelemetrySessionInfo<XfinityTelemetrySessionInfo>(infoView.JsonData);
                        break;
                    }
                case Vehicles.gen6FordFusion:
                    {
                        session = GetTelemetrySessionInfo<CupTelemetrySessionInfo>(infoView.JsonData);
                        break;
                    }
                default:
                    {
                        var errorMessage = String.Format("New Car - CarId:{0} CarClassID:{1} CarClassShortName:{2} CarPath:{3} CarScreenName:{4}", infoView.CarID.ToString(), infoView.CarClassID.ToString(), infoView.CarClassShortName, infoView.CarPath, infoView.CarScreenName);
                        Console.WriteLine(errorMessage);
                        break;
                    }
            }

            if (null!= session)
            {
                session.SetupJSON = infoView.JsonData;
            }                

            return session;
        }
        /// <summary>
        /// Gets the session info *except for* setup data.
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        private static TelemetrySessionInfo GetTelemetrySessionInfo(string jsonString)
        {
            return JsonConvert.DeserializeObject<TelemetrySessionInfo>(jsonString);
        }
        /// <summary>
        /// Gets the session info including car-specific setup data.
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        private static T GetTelemetrySessionInfo<T>(string jsonString)
        {
            var result = JsonConvert.DeserializeObject(jsonString, typeof(T),
                                                       new JsonSerializerSettings()
                                                       { TypeNameHandling = TypeNameHandling.All });
            return (T)result;
        }    
    }
}
