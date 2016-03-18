using System;
using iRacing.TrackSession.Data.Models;

namespace iRacing.TrackSession.Views
{
    public class TrackSessionView
    {
        #region properties
        public Guid TrackSessionId { get; private set; }
        public Guid SessionTypeId { get; set; }
        public string SessionTypeName { get; set; }
        public int CarID { get; set; }
        public string CarName { get; set; }
        public int TrackID { get; set; }
        public string TrackName { get; set; }
        public string AirTemp { get; set; }
        public string TrackTemp { get; set; }
        public string Skies { get; set; }
        public bool IsNight { get; set; }
        #endregion

        #region constructor
        public TrackSessionView(TrackSessionModel model)
        {
            TrackSessionId = model.TrackSessionId;
            SessionTypeId = model.SessionType.SessionTypeId;
            SessionTypeName = model.SessionType.Name;
            CarID = model.Vehicle.VehicleNumber;
            CarName = model.Vehicle.Name;
            TrackID = model.Track.TrackNumber;
            TrackName = model.Track.Name;
            AirTemp = model.AirTemp;
            TrackTemp = model.TrackTemp;
            Skies = model.Skies;
            IsNight = model.Night;
        }
        #endregion
    }
}
