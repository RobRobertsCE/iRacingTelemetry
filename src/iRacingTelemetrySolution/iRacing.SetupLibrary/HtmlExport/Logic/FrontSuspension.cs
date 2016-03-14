using System;

namespace SetupExportParser.Logic
{
    public class FrontSuspension : Suspension, IFrontSuspension
    {
        public double Caster { get; set; }
        public double Camber { get; set; }

        public FrontSuspension(string data) : base(data)
        {
            var cornerData = data.Split('|');
            Camber = Convert.ToDouble(cornerData[6].Split(':')[1].Trim());
            Caster = Convert.ToDouble(cornerData[7].Split(':')[1].Trim());
        }

        public FrontSuspension()
        {
        }
    }

}
