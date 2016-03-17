using iRacing.SetupLibrary.Tires;
using System;
using System.Collections.Generic;
using TestSessionLibrary.Data.Models;

namespace TestSessionLibrary.Views
{
    public class TrackSessionRunView
    {
        #region properties
        string _lapsJson;
        string _tireSheetJson;
        #endregion

        #region properties
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

        public TireSheet TireSheet { get; set; }
        public LapTimes Laps { get; set; }

        public string Caption
        {
            get
            {
                return String.Format("[{0,2}] {1} Laps", RunNumber, Laps.Count);
            }
        }

        public SetupModel Setup { get; set; }
        public TelemetryModel Telemetry { get; private set; }

        //private string _tireSheetJson;
        //public string TireSheetJson
        //{
        //    get
        //    {
        //        if (null != TireSheet)
        //        {
        //            _tireSheetJson = TireSheet.ToJson();
        //        }
        //        return _tireSheetJson;
        //    }
        //    set
        //    {
        //        _tireSheetJson = value;
        //        if (!String.IsNullOrEmpty(_tireSheetJson))
        //        {
        //            TireSheet = (TireSheet)JsonConvert.DeserializeObject(_tireSheetJson, typeof(TireSheet),
        //                                                  new JsonSerializerSettings()
        //                                                  { TypeNameHandling = TypeNameHandling.All });
        //        }
        //    }
        //}

        //private string _lapsJson;
        //public string LapsJson
        //{
        //    get
        //    {
        //        if (null != Laps)
        //        {
        //            _lapsJson = Laps.ToJson();
        //        }
        //        return _lapsJson;
        //    }
        //    set
        //    {
        //        _lapsJson = value;
        //        if (!String.IsNullOrEmpty(_lapsJson))
        //        {
        //            Laps = (LapTimes)JsonConvert.DeserializeObject(_lapsJson, typeof(LapTimes),
        //                                                  new JsonSerializerSettings()
        //                                                  { TypeNameHandling = TypeNameHandling.All });
        //        }
        //    }
        //}
      
        #endregion

        #region properties
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
            _lapsJson = model.LapsJson;
            _tireSheetJson = model.TireSheetJson;
        }
        #endregion
    }
}
