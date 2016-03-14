using System;

namespace SetupExportParser.SetupModels.LMSC
{
    public class LMSCRearSuspension : Logic.RearSuspension, ILMSCRearSuspension
    {

        //<br>Truck arm mount: <U>middle</U><br>Truck arm preload: <U>16.3 ft-lbs</U><br><br>

        public string TruckArmMount { get; set; }
        public double TruckArmPreload { get; set; }

        public LMSCRearSuspension(string data) : base(data)
        {
            dynamic cornerData = data.Split('|');
            TruckArmMount = Convert.ToDouble(cornerData(7).Split(":")(1).Trim());
            if ((cornerData.Length > 7) && (cornerData(8).Contains("Truck arm preload")))
            {
                TruckArmPreload = Convert.ToDouble(cornerData(8).Split(":")(1).Trim().TrimEnd("\""));
            }
        }

        public LMSCRearSuspension() : base()
        {

        }

    }
}
