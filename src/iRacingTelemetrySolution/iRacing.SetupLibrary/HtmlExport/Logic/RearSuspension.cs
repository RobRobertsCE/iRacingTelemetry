using System;

namespace SetupExportParser.Logic
{
    public class RearSuspension : Suspension, IRearSuspension
    {
        public double TrackBarHeight { get; set; }

        public RearSuspension(string data) : base(data)
        {
            var cornerData = data.Split('|');
            TrackBarHeight = Convert.ToDouble(cornerData[6].Split(':')[1].Trim().TrimEnd('\"'));
        }
        
        public RearSuspension()
        {
        }
    }
}
