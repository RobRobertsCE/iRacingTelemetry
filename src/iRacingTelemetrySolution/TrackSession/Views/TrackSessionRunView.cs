using iRacing.SetupLibrary.Tires;
using System;
using System.Collections.Generic;
using iRacing.TrackSession.Data.Models;
using iRacing.TelemetryAnalysis.Laps;

namespace iRacing.TrackSession.Views
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
        public LapTimesView Laps { get; set; }
        public LapTimeAnalysis LapTimeAnalysis { get; set; }

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
            Laps = new LapTimesView();
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
                Laps = LapTimesView.FromJson(model.LapsJson);
            if (!String.IsNullOrEmpty(model.TireSheetJson))
                TireSheet = TireSheet.FromJson(model.TireSheetJson);
        }
        #endregion
    }
}
