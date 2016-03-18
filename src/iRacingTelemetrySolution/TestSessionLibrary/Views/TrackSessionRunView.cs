using iRacing.SetupLibrary.Tires;
using System;
using System.Collections.Generic;
using TrackSessionLibrary.Data.Models;

namespace TrackSessionLibrary.Views
{
    public class TrackSessionRunView
    {
        #region properties
        public Guid TrackSessionRunId { get; private set; }
        public Guid TrackSessionId { get; private set; }
        public Guid SetupId { get; private set; }
        public Guid TelemetryId { get; private set; }
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
        #endregion

        #region constructor
        public TrackSessionRunView()
        {
            Laps = new LapTimes();
            TireSheet = new TireSheet();
        }
        public TrackSessionRunView(TrackSessionRunModel model) :this()
        {
            TrackSessionRunId = model.TrackSessionRunId;
            TrackSessionId = model.TrackSessionId;
            SetupId = model.SetupId;
            TelemetryId = model.TelemetryId;
            RunNumber = model.RunNumber;
            if (!String.IsNullOrEmpty (model.LapsJson))
                Laps = LapTimes.FromJson(model.LapsJson);
            if (!String.IsNullOrEmpty(model.TireSheetJson))
                TireSheet = TireSheet.FromJson(model.TireSheetJson);
        }
        #endregion
    }
}
