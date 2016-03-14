using System;
using System.Collections.Generic;
using System.Linq;

namespace SetupExportParser.Logic
{
    public class Tire : ITire
    {
        public double ColdPSI { get; set; }
        public double LastHotPSI { get; set; }
        public double LastTempO { get; set; }
        public double LastTempM { get; set; }
        public double LastTempI { get; set; }
        public int TreadRemainingO { get; set; }
        public int TreadRemainingM { get; set; }
        public int TreadRemainingI { get; set; }
        public double Stagger { get; set; }
        //*** calculated ***//
        public double PSIGain
        {
            get { return LastHotPSI - ColdPSI; }
        }
        public double TempSpread
        {
            get
            {
                List<double> temps = new List<double> {
                LastTempI,
                LastTempM,
                LastTempO
            };
                return temps.Max() - temps.Min();
            }
        }
        public double WearSpread
        {
            get
            {
                List<double> wears = new List<double> {
                TreadRemainingO,
                TreadRemainingM,
                TreadRemainingI
            };
                return wears.Max() - wears.Min();
            }
        }

        public Tire()
        {
        }

        public Tire(string data)
        {
            var tireData = data.Split('|');
            ColdPSI = Convert.ToDouble(tireData[0].Split(':')[1].Trim());
            LastHotPSI = Convert.ToDouble(tireData[1].Split(':')[1].Trim());

            if ((tireData[2].Split(':')[0].EndsWith("I")))
            {
                LastTempO = Convert.ToDouble(tireData[2].Split(':')[1].Trim().TrimEnd('F'));
                LastTempM = Convert.ToDouble(tireData[3].Trim().Replace("F", ""));
                LastTempI = Convert.ToDouble(tireData[4].Trim().Replace("F", ""));
                TreadRemainingO = Convert.ToInt32(tireData[5].Split(':')[1].Trim().TrimEnd('%'));
                TreadRemainingM = Convert.ToInt32(tireData[6].Trim().TrimEnd('%'));
                TreadRemainingI = Convert.ToInt32(tireData[7].Trim().TrimEnd('%'));
            }
            else {
                LastTempI = Convert.ToDouble(tireData[2].Split(':')[1].Trim().TrimEnd('F'));
                LastTempM = Convert.ToDouble(tireData[3].Trim().Replace("F", ""));
                LastTempO = Convert.ToDouble(tireData[4].Trim().Replace("F", ""));
                TreadRemainingI = Convert.ToInt32(tireData[5].Split(':')[1].Trim().TrimEnd('%'));
                TreadRemainingM = Convert.ToInt32(tireData[6].Trim().TrimEnd('%'));
                TreadRemainingO = Convert.ToInt32(tireData[7].Trim().TrimEnd('%'));
            }
            if (tireData[8].Contains("Stagger"))
            {
                Stagger = Convert.ToDouble(tireData[8].Split(':')[1].Trim().Replace("\"", ""));
            }
        }
    }
}
