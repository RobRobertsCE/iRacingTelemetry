using System;

namespace SetupExportParser.Logic
{
    public class Suspension : ISuspension
    {
        public int Weight { get; set; }
        public double Height { get; set; }
        public double ScrewJack { get; set; }
        public int SpringRate { get; set; }
        public int BumpStiffness { get; set; }
        public int ReboundStiffness { get; set; }

        public Suspension(string data)
        {
            var cornerData = data.Split('|');
            //Corner weight: <U>589 lbs</U><br>Ride height: <U>2.016 in</U><br>Shock collar offset: <U>5.500"</U><br>Spring rate: <U>600 lbs/in</U><br>Bump stiffness: <U>+6 clicks</U><br>Rebound stiffness: <U>+6 clicks</U><br>Camber: <U>+3.4 deg</U><br>Caster: <U>+4.6 deg</U><br><br>
            Weight = Convert.ToInt32(cornerData[0].Split(':')[1].Trim());
            Height = Convert.ToDouble(cornerData[1].Split(':')[1].Trim());
            ScrewJack = Convert.ToDouble(cornerData[2].Split(':')[1].Trim().TrimEnd('\"'));
            SpringRate = Convert.ToInt32(cornerData[3].Split(':')[1].Replace("in", "").Replace('/', ' ').Trim());
            BumpStiffness = Convert.ToInt32(cornerData[4].Split(':')[1].Trim());
            ReboundStiffness = Convert.ToInt32(cornerData[5].Split(':')[1].Trim());
        }

        public Suspension()
        {
        }
    }
}
