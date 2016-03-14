using Newtonsoft.Json;
using System;

namespace iRacing.SetupLibrary.Parsers
{
    public class SetupParserBase : IDisposable
    {
        protected ICarSetup ParseJSON(Vehicles vehicle, string json)
        {
            switch (vehicle)
            {
                case Vehicles.legends:
                    {
                        return GetTelemetrySessionInfo<LegendsSetup>(json);
                    }
                case Vehicles.streetstock:
                    {
                        return GetTelemetrySessionInfo<SSSetup>(json);
                    }
                case Vehicles.latemodel:
                    {
                        return GetTelemetrySessionInfo<LMSCSetup>(json);
                    }
                case Vehicles.kandnseries:
                    {
                        return GetTelemetrySessionInfo<KNSetup>(json);
                    }
                case Vehicles.superlatemodel:
                    {
                        return GetTelemetrySessionInfo<SLMSetup>(json);
                    }
                case Vehicles.skmodified:
                    {
                        return GetTelemetrySessionInfo<ModifiedSetup>(json);
                    }
                case Vehicles.tourmodified:
                    {
                        return GetTelemetrySessionInfo<ModifiedSetup>(json);
                    }
                case Vehicles.silverado2015:
                    {
                        return GetTelemetrySessionInfo<CClassSetup>(json);
                    }
                case Vehicles.xfinityFordMustang:
                    {
                        return GetTelemetrySessionInfo<BClassSetup>(json);
                    }
                case Vehicles.gen6FordFusion:
                    {
                        return GetTelemetrySessionInfo<AClassSetup>(json);
                    }
                default:
                    {
                        throw new InvalidOperationException(String.Format("Unhandled vehicle type in parser: {0}", vehicle));
                    }
            }
        }

        /// <summary>
        /// Gets the session info including car-specific setup data.
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        private T GetTelemetrySessionInfo<T>(string jsonString)
        {
            var result = JsonConvert.DeserializeObject(jsonString, typeof(T),
                                                       new JsonSerializerSettings()
                                                       { TypeNameHandling = TypeNameHandling.All });
            return (T)result;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~YamlSetupParser() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
