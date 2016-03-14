using System;

namespace SetupExportParser.Logic
{
    public class RearCorner : Corner
    {
        public double TrackBarHeight { get; set; }

        public RearCorner(string data)
        {
            dynamic cornerData = data.Split('|');

            Weight = Convert.ToInt32(cornerData(0).Split(":")(1).Trim());
            Height = Convert.ToDouble(cornerData(1).Split(":")(1).Trim());
            ScrewJack = Convert.ToDouble(Convert.ToDouble(cornerData(2).Split(":")(1).Trim().TrimEnd("\"")));
            SpringRate = Convert.ToInt32(cornerData(3).Split(":")(1).Replace("in", "").Replace("/", "").Trim());
            BumpStiffness = cornerData(4).Split(":")(1).Trim();
            ReboundStiffness = cornerData(5).Split(":")(1).Trim();
            TrackBarHeight = Convert.ToDouble(cornerData(6).Split(":")(1).Trim().TrimEnd("\""));
        }


        public RearCorner()
        {
        }
    }
}
