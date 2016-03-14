using System;

namespace SetupExportParser.Logic
{
    public class FrontCorner : Corner
    {
        public double Caster { get; set; }
        public double Camber { get; set; }

        public FrontCorner(string data)
        {
            dynamic cornerData = data.Split('|');
            Weight = Convert.ToInt32(cornerData(0).Split(":")(1).Trim());
            Height = Convert.ToDouble(cornerData(1).Split(":")(1).Trim());
            ScrewJack = Convert.ToDouble(Convert.ToDouble(cornerData(2).Split(":")(1).Trim().TrimEnd("\"")));
            SpringRate = Convert.ToInt32(cornerData(3).Split(":")(1).Replace("in", "").Replace("/", "").Trim());
            BumpStiffness = Convert.ToInt32(cornerData(4).Split(":")(1).Trim());
            ReboundStiffness = Convert.ToInt32(cornerData(5).Split(":")(1).Trim());
            Camber = Convert.ToDouble(cornerData(6).Split(":")(1).Trim());
            Caster = Convert.ToDouble(cornerData(7).Split(":")(1).Trim());
        }


        public FrontCorner()
        {
        }
    }
}
