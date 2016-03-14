using System;

namespace SetupExportParser.Logic
{
    public class Setup : ISetup
    {
        #region " Properties "
        public virtual Guid SetupId { get; set; }
        public virtual string Name { get; set; }
        public virtual int TrackNumber { get; set; }
        public virtual string TrackName { get; set; }
        public virtual int CarNumber { get; set; }
        public virtual string CarName { get; set; }

        public virtual IFrontSuspension LFSuspension { get; set; }
        public virtual IFrontSuspension RFSuspension { get; set; }
        public virtual IRearSuspension LRSuspension { get; set; }
        public virtual IRearSuspension RRSuspension { get; set; }

        public virtual ITire LFTire { get; set; }
        public virtual ITire RFTire { get; set; }
        public virtual ITire LRTire { get; set; }
        public virtual ITire RRTire { get; set; }

        public virtual int BallastForward { get; set; }
        public virtual double FrontWeightPercent { get; set; }
        public virtual double CrossWeightPercent { get; set; }
        public virtual double ToeIn { get; set; }
        public virtual int SteerRatio { get; set; }
        public virtual double SteerOffset { get; set; }
        public virtual double FtBrakeBias { get; set; }
        public virtual double SwayBarSize { get; set; }
        public virtual int SwayBarArm { get; set; }
        public virtual double SwayBarLeftClearance { get; set; }
        public virtual bool SwayBarLeftAttached { get; set; }
        public virtual double FuelLevel { get; set; }
        public virtual double FinalGearRatio { get; set; }
        public virtual string Notes { get; set; }

        #endregion

        #region " ReadOnly Properties "
        public int TotalWeight
        {
            get { return LeftSideWeight + RightSideWeight; }
        }
        public int LeftSideWeight
        {
            get { return LFSuspension.Weight + LRSuspension.Weight; }
        }
        public int RightSideWeight
        {
            get { return RFSuspension.Weight + RRSuspension.Weight; }
        }
        public int RearWeight
        {
            get { return LRSuspension.Weight + RRSuspension.Weight; }
        }
        public int FrontWeight
        {
            get { return LFSuspension.Weight + RFSuspension.Weight; }
        }
        public int CrossWeight
        {
            get { return LRSuspension.Weight + RFSuspension.Weight; }
        }
        public double LeftWeightPercent
        {
            get { return (LeftSideWeight / TotalWeight) * 100; }
        }
        public double FrontSpringSplit
        {
            get { return RFSuspension.SpringRate - LFSuspension.SpringRate; }
        }

        public double RearSpringSplit
        {
            get { return RRSuspension.SpringRate - LRSuspension.SpringRate; }
        }

        public double FrontHeightSplit
        {
            get { return RFSuspension.Height - LFSuspension.Height; }
        }

        public double RearHeightSplit
        {
            get { return RRSuspension.Height - LRSuspension.Height; }
        }

        public double Rake
        {
            get { return ((RRSuspension.Height + LRSuspension.Height) / 2) - ((RFSuspension.Height + LFSuspension.Height) / 2); }
        }

        public double Lean
        {
            get { return ((RRSuspension.Height + LFSuspension.Height) / 2) - ((LFSuspension.Height + LRSuspension.Height) / 2); }
        }

        public double TrackBarSplit
        {
            get { return LRSuspension.TrackBarHeight - RRSuspension.TrackBarHeight; }
        }

        public double CamberSplit
        {
            get { return LFSuspension.Camber - RFSuspension.Camber; }
        }

        public double CasterSplit
        {
            get { return LFSuspension.Caster - RFSuspension.Caster; }
        }
        #endregion

        #region " Ctor "
        public Setup(string data, int carNumber, int trackNumber) :this(data)
        {
            this.CarNumber = carNumber;
            this.TrackNumber = trackNumber;
        }

        public Setup(string data)
        {
            data = "" + Environment.NewLine + CleanInput(data);

            var dataLines = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            this.Name = dataLines[11].Split(':')[1].Trim().TrimEnd('|');
            this.CarName = dataLines[11].Split(':')[0].Split(' ')[0].Trim();
            this.TrackName = dataLines[12].Split(':')[1].Trim().Replace("</H2>|", "");
            this.LFTire = new Tire(dataLines[16]);
            this.LRTire = new Tire(dataLines[18]);
            this.RFTire = new Tire(dataLines[20]);
            this.RRTire = new Tire(dataLines[22]);

            this.LFSuspension = new FrontSuspension(dataLines[26]);
            this.LRSuspension = new RearSuspension(dataLines[28]);
            this.RFSuspension = new FrontSuspension(dataLines[30]);
            this.RRSuspension = new RearSuspension(dataLines[32]);

            var frontData = dataLines[24].Split('|');
            BallastForward = Convert.ToInt32(frontData[0].Split(':')[1].TrimEnd('\"'));
            FrontWeightPercent = Convert.ToDouble(frontData[1].Split(':')[1].Trim());
            CrossWeightPercent = Convert.ToDouble(frontData[2].Split(':')[1].Trim());
            ToeIn = ConvertFractionToDouble(frontData[3].Split(':')[1].Trim().TrimEnd('\"'));
            SteerRatio = Convert.ToInt32(frontData[4].Split(':')[1].Trim());
            SteerOffset = Convert.ToDouble(frontData[5].Split(':')[1].Trim());
            FtBrakeBias = Convert.ToDouble(frontData[6].Split(':')[1].Trim());
            SwayBarSize = Convert.ToDouble(frontData[7].Split(':')[1].Trim().TrimEnd('\"'));
            SwayBarArm = Convert.ToInt32(frontData[8].Split(':')[1].Trim().TrimEnd('\"'));
            SwayBarLeftClearance = ConvertFractionToDouble(frontData[9].Split(':')[1].Trim().TrimEnd('\"'));
            SwayBarLeftAttached = ("Yes" == frontData[10].Split(':')[1].Trim());

            dynamic rearData = dataLines[34].Split('|');
            FuelLevel = Convert.ToDouble(rearData[0].Split(':')[1].Trim());
            FinalGearRatio = Convert.ToDouble(rearData[1].Split(':')[1].Trim());

            int noteIdx = 36;
            while (!(dataLines[noteIdx].Contains("</body>")))
            {
                this.Notes += dataLines[noteIdx].Trim().TrimEnd('|') + Environment.NewLine;
                noteIdx += 1;
            }

            Initialize(dataLines);
        }

        public Setup()
        {
            this.LFTire = new Tire();
            this.LRTire = new Tire();
            this.RFTire = new Tire();
            this.RRTire = new Tire();

            this.LFSuspension = (IFrontSuspension)new FrontCorner();
            this.LRSuspension = (IRearSuspension)new RearCorner();
            this.RFSuspension = (IFrontSuspension)new FrontCorner();
            this.RRSuspension = (IRearSuspension)new RearCorner();
        }

        protected virtual void Initialize(string[] dataLines)
        {
        }
        #endregion

        #region " Helper Functions "
        // -2/16 in, -.125 out
        public double ConvertFractionToDouble(string data)
        {
            dynamic i = data.Split('/');
            if (i[0].Contains("0"))
            {
                return 0;
            }
            else {
                dynamic n = Convert.ToDouble(i[0].Trim());
                dynamic d = Convert.ToDouble(i[1].Trim());
                return n / d;
            }

        }

        public string CleanInput(string data)
        {
            data = data.Replace("<U>", "");
            data = data.Replace("</U>", "");
            data = data.Replace(" deg", "");
            data = data.Replace(" clicks", "");
            data = data.Replace(" lbs", "");
            data = data.Replace(" gal", "");
            data = data.Replace(" psi", "");
            data = data.Replace(" in", "");
            data = data.Replace(" ft-lbs", "");
            data = data.Replace(" lbs/in", "");
            data = data.Replace("%", "");
            data = data.Replace("+", "");
            data = data.Replace("<br>", "|");
            return data;
        }
        #endregion
    }
}
