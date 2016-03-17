using System;
using System.Collections.Generic;
using TestSessionLibrary.Data.Models;

namespace TestSessionLibrary.Views
{
    public class TrackSessionRunView
    {
        public Guid TrackSessionRunId { get; private set; }
        public int CarID { get; set; }
        public string CarName { get; set; }
        public int TrackID { get; set; }
        public string TrackName { get; set; }
        public string AirTemp { get; set; }
        public string TrackTemp { get; set; }
        public string Skies { get; set; }
        public bool IsNight { get; set; }
        public int RunNumber { get; set; }
        public int LapCount { get; set; }
        public List<LapModel> Laps { get; set; }

        public string Caption
        {
            get
            {
                return String.Format("[{0,2}] {1} Laps", RunNumber, LapCount);
            }
        }

        public SetupModel Setup { get; set; }
        public TelemetryModel Telemetry { get; private set; }

        public TrackSessionRunView(TrackSessionRunModel model)
        {
            TrackSessionRunId = model.TrackSessionRunId;
            CarID = model.TrackSession.VehicleNumber;
            CarName = model.TrackSession.Vehicle.Name;
            TrackID = model.TrackSession.TrackNumber;
            TrackName = model.TrackSession.Track.Name;
            AirTemp = model.TrackSession.AirTemp;
            TrackTemp = model.TrackSession.TrackTemp;
            Skies = model.TrackSession.Skies;
            IsNight = model.TrackSession.Night;
            RunNumber = model.RunNumber;
            Telemetry = model.Telemetry;
            Setup = model.Setup;
            LapCount = model.LapCount;
            Laps = model.Laps;
        }
    }
}
