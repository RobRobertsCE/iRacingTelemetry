using iRacing.SetupLibrary.Tires;
using System;
using System.Collections.Generic;

namespace iRacing.SetupLibrary.Parsers
{
    public class HtmlExportParser : SetupParserBase, ISetupParser
    {
        private enum LineContent
        {
            Vehicle = 10,
            Setup=10,
            Track =11,
            LFTire=15,
            LRTire= 17,
            RFTire= 19,
            RRTire=21
        }

        char tab = '\u0009';

        public ICarSetup GetSetup(Vehicles vehicle, string setupData)
        {
            throw new NotImplementedException();
        }

        public TireSheet GetTireSheet(string htmlExport)
        {
            return GetTireSheet(null, htmlExport);
        }
        public TireSheet GetTireSheet(Guid? trackSessionRunId, string htmlExport)
        {
            var lines = htmlExport.Split('\n');

            var tireSheet = new TireSheet(trackSessionRunId);

            tireSheet.VehicleName = GetVehicleName(lines);
            tireSheet.SetupName  = GetSetupName(lines);
            tireSheet.TrackName = GetTrackName(lines);

            tireSheet.LF = GetTireDetails(LineContent.LFTire, lines);
            tireSheet.LR = GetTireDetails(LineContent.LRTire, lines);
            tireSheet.RF = GetTireDetails(LineContent.RFTire, lines);
            tireSheet.RR = GetTireDetails(LineContent.RRTire, lines);

            return tireSheet;
        }

        private string GetVehicleName(IList<string> lines)
        {
            var line = lines[(int)LineContent.Vehicle].Replace(tab.ToString(),"");
            var idx = line.IndexOf(" setup:");
            var vehicle = line.Substring(0, idx);
            return vehicle;
        }
        private string GetSetupName(IList<string> lines)
        {
            var line = lines[(int)LineContent.Setup].Replace(tab.ToString(), "");
            var idx = line.IndexOf(" setup:");
            var setup = line.Substring(idx + 7).Replace(tab.ToString(),"").Replace(@"&gt;<br>", "").Replace(@"&lt;", "").Replace("\r", "").Trim();
            return setup;
        }
        private string GetTrackName(IList<string> lines)
        {
            var line = lines[(int)LineContent.Track].Replace(tab.ToString(), "");
            var idx = line.IndexOf(":");
            var track = line.Substring(idx + 2).Replace("</H2><br> ", "").Replace("\r", "").Trim();
            return track;
        }
        private TireDetails GetTireDetails(LineContent tirePosition, IList<string> lines)
        {
            var details = new TireDetails();
            var line = lines[(int)tirePosition];
            var splitLine = line.Split(new string[] { "<br>" }, StringSplitOptions.None);

            details.ColdPsi = Convert.ToSingle(splitLine[0].Replace(" psi</U>", "").Split(new string[] { "<U>" }, StringSplitOptions.None)[1]);
            details.HotPsi = Convert.ToSingle(splitLine[1].Replace(" psi</U>", "").Split(new string[] { "<U>" }, StringSplitOptions.None)[1]);

            
            if (tirePosition == LineContent.LFTire || tirePosition == LineContent.LRTire)
            {                
                details.OutsideTemp = Convert.ToSingle(splitLine[2].Replace("Last temps O M I: <U>", "").Replace("F</U>", ""));
                details.MiddleTemp = Convert.ToSingle(splitLine[3].Replace("<U>","").Replace("F</U>", ""));
                details.InsideTemp = Convert.ToSingle(splitLine[4].Replace("<U>", "").Replace("F</U>", ""));

                details.OutsideWear = Convert.ToSingle(splitLine[5].Replace("Tread remaining: <U>", "").Replace("%</U>", ""));
                details.MiddleWear = Convert.ToSingle(splitLine[6].Replace("<U>", "").Replace("%</U>", ""));
                details.InsideWear = Convert.ToSingle(splitLine[7].Replace("<U>", "").Replace("%</U>", ""));
            }
            else
            {
                details.InsideTemp = Convert.ToSingle(splitLine[2].Replace("Last temps I M O: <U>", "").Replace("F</U>", ""));
                details.MiddleTemp = Convert.ToSingle(splitLine[3].Replace("<U>", "").Replace("F</U>", ""));
                details.OutsideTemp = Convert.ToSingle(splitLine[4].Replace("<U>", "").Replace("F</U>", ""));

                details.InsideWear = Convert.ToSingle(splitLine[5].Replace("Tread remaining: <U>", "").Replace("%</U>", ""));
                details.MiddleWear = Convert.ToSingle(splitLine[6].Replace("<U>", "").Replace("%</U>", ""));
                details.OutsideWear = Convert.ToSingle(splitLine[7].Replace("<U>", "").Replace("%</U>", ""));
            }

            if (splitLine.Length == 9)
                details.Stagger = Convert.ToSingle(splitLine[8].Replace(" psi</U>", "").Split(new string[] { "<U>" }, StringSplitOptions.None)[1]);

            //   0 - Cold pressure:<U>18.0 psi</U>
            //   1 - Last hot pressure:<U>19.2 psi</U>
            //   2 - Last temps O M I:<U>143F</U>
            //   3 - <U>143F</U>
            //   4 - <U>122F</U>
            //   5 - Tread remaining:<U>100 %</U>
            //   6 - <U>100 %</U>
            //   7 - <U>100 %</U>
            //   8 - Stagger: <U>2.250"</U>

            return details;
        }
        /*
        Lines:
        11 - vehiclename, setup name
        			skmodified tour setup: snmp-2016s1-111-1-race2<br> 
        12 - track name
        			track: southernnational</H2><br> 
        16 - LF Tire Sheet Data
        18 - LR Tire Sheet Data
        20 - RF Tire Sheet Data
        22 - RR Tire Sheet Data

        Left Side Tire Sheet Data: (Left = O M I, Right = I M O)
        Cold pressure: <U>18.0 psi</U><br>Last hot pressure: <U>19.2 psi</U><br>Last temps O M I: <U>143F</U><br><U>143F</U><br><U>122F</U><br>Tread remaining: <U>100%</U><br><U>100%</U><br><U>100%</U><br><br>




        Right Side Tire Sheet Data (with stagger): (Right = I M O)
        Cold pressure: <U>20.0 psi</U><br>Last hot pressure: <U>22.2 psi</U><br>Last temps I M O: <U>159F</U><br><U>159F</U><br><U>154F</U><br>Tread remaining: <U>100%</U><br><U>100%</U><br><U>100%</U><br>Stagger: <U>2.250"</U><br><br>
    */
    }
}
