using Newtonsoft.Json;
using System;

namespace IbtSetupParser
{
    public class SetupParser
    {
        #region Enumerations
        public enum SetupSections
        {
            UpdateCount,
            Tires,
            Chassis
        }
        public enum SetupGroups
        {
            Front,
            LeftFront,
            LeftRear,
            FrontARB,
            RightFront,
            RightRear,
            Rear
        }
        #endregion

        #region Fields
        SetupSections _section = SetupSections.UpdateCount;
        SetupGroups _group = SetupGroups.Front;
        Setup _setup = null;
        #endregion

        #region Properties
        public Setup ChassisSetup
        {
            get
            {
                return _setup;
            }
            private set
            {
                _setup = value;
            }
        }
        #endregion

        #region Public Methods
        public Setup Parse(string data)
        {
            _setup = new Setup();

            int setupStart = data.IndexOf("CarSetup:");
            int setupEnd = data.IndexOf("...");

            if (setupEnd == -1)
                setupEnd = data.Length;

            string[] lines = data.Substring(setupStart, setupEnd - setupStart).Split('\n');

            ParseLines(lines);

            return _setup;
        }
        #endregion

        #region Private Methods - Parsing
        private void ParseLines(string[] lines)
        {
            foreach (var line in lines)
            {
                if (!String.IsNullOrEmpty(line.Trim()))
                {
                    if (line.StartsWith("   "))
                    {
                        ParseSetupValue(_section, _group, line);
                    }
                    // Group
                    else if (line.StartsWith("  "))
                    {
                        if (line.Contains("LeftFront:"))
                        {
                            _group = SetupGroups.LeftFront;
                        }
                        else if (line.Contains("LeftRear:"))
                        {
                            _group = SetupGroups.LeftRear;
                        }
                        else if (line.Contains("FrontARB:"))
                        {
                            _group = SetupGroups.FrontARB;
                        }
                        else if (line.Contains("RightFront:"))
                        {
                            _group = SetupGroups.RightFront;
                        }
                        else if (line.Contains("RightRear:"))
                        {
                            _group = SetupGroups.RightRear;
                        }
                        else if (line.Contains("Rear:"))
                        {
                            _group = SetupGroups.Rear;
                        }
                        else if (line.Contains("Front:"))
                        {
                            _group = SetupGroups.Front;
                        }
                    }
                    // Section
                    else if (line.StartsWith(" "))
                    {
                        if (line.Contains("UpdateCount:"))
                        {
                            _section = SetupSections.UpdateCount;
                            // this line has the value and section name on the same line.
                            ParseSetupValue(_section, _group, line);
                        }
                        else if (line.Contains("Tires:"))
                        {
                            _section = SetupSections.Tires;
                        }
                        else if (line.Contains("Chassis:"))
                        {
                            _section = SetupSections.Chassis;
                        }
                    }
                    else
                    {
                        // CarSetup:
                        // Skip, go to next line.
                    }
                }
            }
        }
        private void ParseSetupValue(SetupSections section, SetupGroups group, string line)
        {
            switch (section)
            {
                case SetupSections.UpdateCount:
                    {
                        ParseUpdateCountValue(line);
                        break;
                    }
                case SetupSections.Tires:
                    {
                        ParseTiresValue(group, line);
                        break;
                    }
                case SetupSections.Chassis:
                    {
                        ParseChassisValue(group, line);
                        break;
                    }
            }
        }
        private void ParseUpdateCountValue(string line)
        {
            var kv = line.Split(':');
            _setup.UpdateCount = Convert.ToInt32(kv[1].Trim());
        }
        // tires //
        private void ParseTiresValue(SetupGroups group, string line)
        {
            switch (group)
            {
                case SetupGroups.LeftFront:
                    {
                        ParseLeftTireValue(_setup.Tires.LF, line);
                        break;
                    }
                case SetupGroups.LeftRear:
                    {
                        ParseLeftTireValue(_setup.Tires.LR, line);
                        break;
                    }
                case SetupGroups.RightFront:
                    {
                        ParseRightTireValue(_setup.Tires.RF, line);
                        break;
                    }
                case SetupGroups.RightRear:
                    {
                        ParseRightTireValue(_setup.Tires.RR, line);
                        break;
                    }
            }
        }
        private void ParseLeftTireValue(Setup.SetupTires.LeftTire tire, string line)
        {
            /*
                LeftFront:
                ColdPressure: 138 kPa
                LastHotPressure: 138 kPa
                LastTempsOMI: 27C, 27C, 27C
                TreadRemaining: 100%, 100%, 100%
            */
            var kv = line.Split(':');
            switch (kv[0].Trim())
            {
                case "ColdPressure":
                    {
                        var psi = GetValue(kv[1]);
                        tire.ColdPressure = (Single)Math.Round(psi, 1);
                        break;
                    }
                case "LastHotPressure":
                    {
                        var psi = GetValue(kv[1]);
                        tire.LastHotPressure = (Single)Math.Round(psi, 1);
                        break;
                    }
                case "LastTempsOMI":
                    {
                        // LastTempsIMO: 27C, 27C, 27C
                        var imo = kv[1].Split(',');
                        tire.LastTempsOMI[0] = GetValue(imo[0].Trim());
                        tire.LastTempsOMI[1] = GetValue(imo[1].Trim());
                        tire.LastTempsOMI[2] = GetValue(imo[2].Trim());
                        break;
                    }
                case "TreadRemaining":
                    {
                        // TreadRemaining: 100%, 100%, 100%
                        var imo = kv[1].Split(',');
                        tire.TreadRemaining[0] = Convert.ToInt32(GetValue(imo[0].Trim()));
                        tire.TreadRemaining[1] = Convert.ToInt32(GetValue(imo[1].Trim()));
                        tire.TreadRemaining[2] = Convert.ToInt32(GetValue(imo[2].Trim()));
                        break;
                    }
            }
        }
        private void ParseRightTireValue(Setup.SetupTires.RightTire tire, string line)
        {
            /*
                RightRear:
                ColdPressure: 152 kPa
                LastHotPressure: 152 kPa
                LastTempsIMO: 27C, 27C, 27C
                TreadRemaining: 100%, 100%, 100%
                Stagger: 41 mm
            */
            var kv = line.Split(':');
            switch (kv[0].Trim())
            {
                case "ColdPressure":
                    {
                        var psi = GetValue(kv[1]);
                        tire.ColdPressure = (Single)Math.Round(psi, 1);
                        break;
                    }
                case "LastHotPressure":
                    {
                        var psi = GetValue(kv[1]);
                        tire.LastHotPressure = (Single)Math.Round(psi, 1);
                        break;
                    }
                case "LastTempsIMO":
                    {
                        // LastTempsIMO: 27C, 27C, 27C
                        var imo = kv[1].Split(',');
                        tire.LastTempsIMO[0] = GetValue(imo[0].Trim());
                        tire.LastTempsIMO[1] = GetValue(imo[1].Trim());
                        tire.LastTempsIMO[2] = GetValue(imo[2].Trim());
                        break;
                    }
                case "TreadRemaining":
                    {
                        // TreadRemaining: 100%, 100%, 100%
                        var imo = kv[1].Split(',');
                        tire.TreadRemaining[0] = Convert.ToInt32(GetValue(imo[0].Trim()));
                        tire.TreadRemaining[1] = Convert.ToInt32(GetValue(imo[1].Trim()));
                        tire.TreadRemaining[2] = Convert.ToInt32(GetValue(imo[2].Trim()));
                        break;
                    }
                case "Stagger":
                    {
                        var stagger = GetValue(kv[1]);
                        tire.Stagger = (Single)(Math.Round(stagger * 16, MidpointRounding.ToEven) / 16);
                        break;
                    }
            }
        }
        // chassis //
        private void ParseChassisValue(SetupGroups group, string line)
        {
            switch (group)
            {
                case SetupGroups.Front:
                    {
                        ParseChassisFrontValue(_setup.Chassis.Front, line);
                        break;
                    }
                case SetupGroups.LeftFront:
                    {
                        ParseChassisFrontCornerValue(_setup.Chassis.LeftFront, line);
                        break;
                    }
                case SetupGroups.LeftRear:
                    {
                        ParseChassisRearCornerValue(_setup.Chassis.LeftRear, line);
                        break;
                    }
                case SetupGroups.RightFront:
                    {
                        ParseChassisFrontCornerValue(_setup.Chassis.RightFront, line);
                        break;
                    }
                case SetupGroups.RightRear:
                    {
                        ParseChassisRearCornerValue(_setup.Chassis.RightRear, line);
                        break;
                    }
                case SetupGroups.Rear:
                    {
                        ParseChassisRearValue(_setup.Chassis.Rear, line);
                        break;
                    }
            }
        }
        private void ParseChassisFrontCornerValue(Setup.SetupChassis.FrontCorner corner, string line)
        {
            /*
                CornerWeight: 3432 N
                RideHeight: 111 mm
                SpringPerchOffset: 123 mm
                SpringRate: 61 N/mm
                BumpStiffness: +13 clicks
                ReboundStiffness: +11 clicks
                Camber: -2.7 deg
                Caster: +3.1 deg
                Packer: 0.0 mm shim
                ShockDeflection: 47.4 mm 142.0 mm
                SpringDeflection: 69.4 mm 183.5 mm      
            */
            var kv = line.Split(':');
            switch (kv[0].Trim())
            {
                case "Packer":
                    {
                        // Packer: 0.0 mm shim
                        corner.Packer = GetValue(kv[1]);
                        break;
                    }
                case "ShockDeflection":
                    {
                        // ShockDeflection: 47.4 mm 142.0 mm
                        var values = kv[1].Split(' ');
                        var current = MMToInches(Convert.ToSingle(values[0]));
                        var max = MMToInches(Convert.ToSingle(values[3]));
                        corner.ShockDeflection = new Setup.SetupChassis.DeflectionSetting() { Position = current, Max = max };
                        break;
                    }
                case "SpringDeflection":
                    {
                        // SpringDeflection: 69.4 mm 183.5 mm
                        var values = kv[1].Split(' ');
                        var current = MMToInches(Convert.ToSingle(values[0]));
                        var max = MMToInches(Convert.ToSingle(values[3]));
                        corner.SpringDeflection = new Setup.SetupChassis.DeflectionSetting() { Position = current, Max = max };
                        break;
                    }
                case "CornerWeight":
                    {
                        corner.CornerWeight = Convert.ToInt32(GetValue(kv[1]));
                        break;
                    }
                case "RideHeight":
                    {
                        corner.RideHeight = GetValue(kv[1]);
                        break;
                    }
                case "SpringPerchOffset":
                    {
                        corner.SpringPerchOffset = GetValue(kv[1]);
                        break;
                    }
                case "SpringRate":
                    {
                        corner.SpringRate = (int)GetValue(kv[1]);
                        break;
                    }

                case "BumpStiffness":
                    {
                        corner.BumpStiffness = Convert.ToInt32(GetValue(kv[1]));
                        break;
                    }
                case "ReboundStiffness":
                    {
                        corner.ReboundStiffness = Convert.ToInt32(GetValue(kv[1]));
                        break;
                    }
                case "Camber":
                    {
                        corner.Camber = GetValue(kv[1]);
                        break;
                    }
                case "Caster":
                    {
                        corner.Caster = GetValue(kv[1]);
                        break;
                    }
            }
        }
        private void ParseChassisRearCornerValue(Setup.SetupChassis.RearCorner corner, string line)
        {
            /*
                CornerWeight: 2812 N
                RideHeight: 113 mm
                SpringPerchOffset: 179 mm
                SpringRate: 74 N/mm
                BumpStiffness: +12 clicks
                ReboundStiffness: +16 clicks
                TrackBarHeight: +279 mm
                TruckArmMount: top
                TruckArmPreload: -2.1 Nm
                Packer: 0.0 mm shim
                ShockDeflection: 47.4 mm 142.0 mm
                SpringDeflection: 69.4 mm 183.5 mm                
            */
            var kv = line.Split(':');
            switch (kv[0].Trim())
            {
                case "Packer":
                    {
                        // Packer: 0.0 mm shim
                        corner.Packer = GetValue(kv[1]);
                        break;
                    }
                case "ShockDeflection":
                    {
                        // ShockDeflection: 47.4 mm 142.0 mm
                        var values = kv[1].Split(' ');
                        var current = MMToInches(Convert.ToSingle(values[0]));
                        var max = MMToInches(Convert.ToSingle(values[3]));
                        corner.ShockDeflection = new Setup.SetupChassis.DeflectionSetting() { Position = current, Max = max };
                        break;
                    }
                case "SpringDeflection":
                    {
                        // SpringDeflection: 69.4 mm 183.5 mm
                        var values = kv[1].Split(' ');
                        var current = MMToInches(Convert.ToSingle(values[0]));
                        var max = MMToInches(Convert.ToSingle(values[3]));
                        corner.SpringDeflection = new Setup.SetupChassis.DeflectionSetting() { Position = current, Max = max };
                        break;
                    }
                case "CornerWeight":
                    {
                        corner.CornerWeight = Convert.ToInt32(GetValue(kv[1]));
                        break;
                    }
                case "RideHeight":
                    {
                        corner.RideHeight = GetValue(kv[1]);
                        break;
                    }
                case "SpringPerchOffset":
                    {
                        corner.SpringPerchOffset = GetValue(kv[1]);
                        break;
                    }
                case "SpringRate":
                    {
                        corner.SpringRate = (int)GetValue(kv[1]);
                        break;
                    }
                case "BumpStiffness":
                    {
                        corner.BumpStiffness = Convert.ToInt32(GetValue(kv[1]));
                        break;
                    }
                case "ReboundStiffness":
                    {
                        corner.ReboundStiffness = Convert.ToInt32(GetValue(kv[1]));
                        break;
                    }
                case "TrackBarHeight":
                    {
                        corner.TrackBarHeight = Convert.ToInt32(GetValue(kv[1]));
                        break;
                    }
                case "TruckArmMount":
                    {
                        corner.TruckArmMount = kv[1].Trim();
                        break;
                    }
                case "TruckArmPreload":
                    {
                        corner.TruckArmPreload = GetValue(kv[1]);
                        break;
                    }
            }
        }
        private void ParseChassisFrontValue(Setup.SetupChassis.ChassisFront chassisFront, string line)
        {
            /*
                BallastForward: 1219 mm
                NoseWeight: 49.6%
                CrossWeight: 54.8%
                ToeIn: -2 mm
                SteeringRatio: 8:1
                SteeringOffset: +0 deg
                BrakeBalanceBar: 42.0%
                SwayBarSize: 40 mm
                SwayBarArmLength: 330 mm
                LeftBarEndClearance: 0 mm
                AttachLeftSide: 1
                TapeConfiguration: 25%
            */
            var kv = line.Split(':');
            switch (kv[0].Trim())
            {
                case "BallastForward":
                    {
                        chassisFront.BallastForward = Convert.ToInt32(GetValue(kv[1]));
                        break;
                    }
                case "NoseWeight":
                    {
                        chassisFront.NoseWeight = GetValue(kv[1]);
                        break;
                    }
                case "CrossWeight":
                    {
                        chassisFront.CrossWeight = GetValue(kv[1]);
                        break;
                    }
                case "ToeIn":
                    {
                        var toe = GetValue(kv[1]);
                        chassisFront.ToeIn = (Single)(Math.Round(toe * 16, MidpointRounding.ToEven) / 16);
                        break;
                    }
                case "SteeringRatio":
                    {
                        chassisFront.SteeringRatio = Convert.ToInt32(kv[1]);
                        break;
                    }
                case "SteeringOffset":
                    {
                        chassisFront.SteeringOffset = GetValue(kv[1]);
                        break;
                    }
                case "BrakeBalanceBar":
                    {
                        chassisFront.BrakeBalanceBar = GetValue(kv[1]);
                        break;
                    }

                case "SwayBarSize":
                    {
                        var swayBar = GetValue(kv[1]);
                        chassisFront.SwayBarSize = (Single)(Math.Round(swayBar * 16, MidpointRounding.ToEven) / 16);
                        break;
                    }
                case "SwayBarArmLength":
                    {
                        chassisFront.SwayBarArmLength = Convert.ToInt32(GetValue(kv[1]));
                        break;
                    }
                case "LeftBarEndClearance":
                    {
                        var clearance = GetValue(kv[1]);
                        chassisFront.LeftBarEndClearance = (Single)(Math.Round(clearance * 16, MidpointRounding.ToEven) / 16);
                        break;
                    }
                case "AttachLeftSide":
                    {
                        chassisFront.AttachLeftSide = ("1" == kv[1]);
                        break;
                    }
                case "TapeConfiguration":
                    {
                        chassisFront.TapeConfiguration = GetValue(kv[1]);
                        break;
                    }
            }
        }
        private void ParseChassisRearValue(Setup.SetupChassis.ChassisRear chassisRear, string line)
        {
            /*
                FuelFillTo: 34.1 L
                RearEndRatio: 5.41
            */
            var kv = line.Split(':');
            switch (kv[0].Trim())
            {
                case "FuelFillTo":
                    {
                        chassisRear.FuelFillTo = GetValue(kv[1]);
                        break;
                    }
                case "RearEndRatio":
                    {
                        chassisRear.RearEndRatio = Convert.ToSingle((kv[1]));
                        break;
                    }
            }
        }
        #endregion

        #region Private Methods - Conversions
        private const Single Kpa_Psi = 0.14503773773020923F;
        private const Single Liters_Gallons = 0.264172F;
        private const Single Newtons_Pounds = 0.224809F;
        private const Single NewtonMeters_PoundsInch = 0.00014503773773022F;
        private const Single NewtonMillimeters_PoundsInch = 5.71014716277F;
        private const Single MM_Inch = 0.0393700787F;
        
        private Single GetValue(string setupValue)
        {
            Single result = 0F;

            setupValue = setupValue.TrimEnd('\r');
            if (setupValue.EndsWith(" kPa"))
            {
                // ColdPressure: 145 kPa
                var buffer = setupValue.Replace(" kPa", "");
                var singleBuffer = Convert.ToSingle(buffer);
                result = KpaToPsi(singleBuffer);
            }
            else if (setupValue.EndsWith("C"))
            {
                // LastTempsIMO: 27C, 27C, 27C
                var buffer = setupValue.Replace("C", "");
                var singleBuffer = Convert.ToSingle(buffer);
                result = CelciusToFarenheit(singleBuffer);
            }
            else if (setupValue.EndsWith(" mm"))
            {
                // SwayBarArmLength: 330 mm
                var buffer = setupValue.Replace(" mm", "");
                var singleBuffer = Convert.ToSingle(buffer);
                result = MMToInches(singleBuffer);
            }
            else if (setupValue.EndsWith(" Nm"))
            {
                // TruckArmPreload: -2.1 Nm
                var buffer = setupValue.Replace(" Nm", "");
                var singleBuffer = Convert.ToSingle(buffer);
                result = NmToLbsIn(singleBuffer);
            }
            else if (setupValue.EndsWith(" N/mm"))
            {
                // SpringRate: 70 N/mm
                var buffer = setupValue.Replace(" N/mm", "");
                var singleBuffer = Convert.ToSingle(buffer);
                result = NmmToLbsIn(singleBuffer);
                result = (int)Math.Round(result / 25.0) * 25;
            }
            else if (setupValue.EndsWith(" N"))
            {
                // CornerWeight: 3507 N
                var buffer = setupValue.Replace(" N", "");
                var singleBuffer = Convert.ToSingle(buffer);
                result = NewtonsToPounds(singleBuffer);
                result = (Single)Math.Round(result, 0);
            }
            else if (setupValue.EndsWith("%"))
            {
                // TreadRemaining: 100%, 100%, 100%
                // BrakeBalanceBar: 42.0%
                var buffer = setupValue.Replace("%", "");
                result = Convert.ToSingle(buffer);
            }
            else if (setupValue.EndsWith(" deg"))
            {
                // Camber: -2.7 deg
                // SteeringOffset: +0 deg
                var buffer = setupValue.Replace(" deg", "").Replace("+", "");
                result = Convert.ToSingle(buffer);
            }
            else if (setupValue.EndsWith(" clicks"))
            {
                // BumpStiffness: +12 clicks
                var buffer = setupValue.Replace(" clicks", "").Replace("+", "");
                result = Convert.ToSingle(buffer);
            }
            else if (setupValue.EndsWith(" L"))
            {
                // FuelFillTo: 34.1 L
                var buffer = setupValue.Replace(" L", "");
                var singleBuffer = Convert.ToSingle(buffer);
                result = LitersToGallons(singleBuffer);
            }
            else if (setupValue.EndsWith(" mm shim"))
            {
                // FuelFillTo: 34.1 L
                var buffer = setupValue.Replace(" mm shim", "");
                var singleBuffer = Convert.ToSingle(buffer);
                result = MMToInches(singleBuffer);
            }
            else
            {
                result = 0;
            }

            return (Single)Math.Round(result, 2);
        }
        private Single KpaToPsi(Single kpa)
        {
            return kpa * Kpa_Psi;
        }
        private Single CelciusToFarenheit(Single celcius)
        {
            return (float)(((9.0 / 5.0) * celcius) + 32);
        }
        private Single LitersToGallons(Single liters)
        {
            return liters * Liters_Gallons;
        }
        private Single NewtonsToPounds(Single newtons)
        {
            return newtons * Newtons_Pounds;
        }
        private Single NmmToLbsIn(Single Nmm)
        {
            return Nmm * NewtonMillimeters_PoundsInch;
        }
        private Single NmToLbsIn(Single Nm)
        {
            return Nm * NewtonMeters_PoundsInch;
        }
        private Single MMToInches(Single mm)
        {
            return mm * MM_Inch;
        }
        #endregion

        #region Classes
        public class Setup
        {
            public int UpdateCount { get; set; }
            public SetupTires Tires { get; set; }
            public SetupChassis Chassis { get; set; }

            public Setup()
            {
                Tires = new SetupTires();
                Chassis = new SetupChassis();
            }

            public string ToJSON()
            {
                string json = JsonConvert.SerializeObject(this, Formatting.Indented);
                return json;
            }

            public static Setup FromJSON(string json)
            {
                Setup newSetup = JsonConvert.DeserializeObject<Setup>(json);
                return newSetup;
            }

            public class SetupTires
            {
                public LeftTire LF { get; set; }
                public LeftTire LR { get; set; }
                public RightTire RF { get; set; }
                public RightTire RR { get; set; }

                public SetupTires()
                {
                    LF = new LeftTire();
                    LR = new LeftTire();
                    RF = new RightTire();
                    RR = new RightTire();
                }
                public class Tire
                {
                    public Single ColdPressure { get; set; }
                    public Single LastHotPressure { get; set; }
                }
                public class LeftTire : Tire
                {
                    public Single[] LastTempsOMI { get; set; }
                    public int[] TreadRemaining { get; set; }
                    public LeftTire()
                    {
                        LastTempsOMI = new Single[3];
                        TreadRemaining = new int[3]; 
                    }
                }
                public class RightTire : Tire
                {
                    public Single[] LastTempsIMO { get; set; }
                    public int[] TreadRemaining { get; set; }
                    public Single Stagger { get; set; }
                    public RightTire()
                    {
                        LastTempsIMO = new Single[3];
                        TreadRemaining = new int[3];
                    }
                }
            }
            public class SetupChassis
            {
                public ChassisFront Front { get; set; }
                public ChassisRear Rear { get; set; }
                public FrontCorner LeftFront { get; set; }
                public RearCorner LeftRear { get; set; }
                public FrontCorner RightFront { get; set; }
                public RearCorner RightRear { get; set; }

                public SetupChassis()
                {
                    Front = new ChassisFront();
                    Rear = new ChassisRear();
                    LeftFront = new FrontCorner();
                    LeftRear = new RearCorner();
                    RightFront = new FrontCorner();
                    RightRear = new RearCorner();
                }
                public class ChassisFront
                {
                    //Front:
                    // BallastForward: 0 mm
                    // NoseWeight: 48.8%
                    // CrossWeight: 50.9%
                    // ToeIn: +1 mm
                    // SteeringRatio: 14:1
                    // SteeringOffset: +0 deg
                    // BrakeBalanceBar: 47.6%
                    // SwayBarSize: 32 mm
                    // SwayBarArmLength: 330 mm
                    // LeftBarEndClearance: 0 mm
                    // AttachLeftSide: 1
                    // TapeConfiguration: 50%
                    public Single BallastForward { get; set; }
                    public Single NoseWeight { get; set; }
                    public Single CrossWeight { get; set; }
                    public Single ToeIn { get; set; }
                    public int SteeringRatio { get; set; }
                    public Single SteeringOffset { get; set; }
                    public Single BrakeBalanceBar { get; set; }
                    public Single SwayBarSize { get; set; }
                    public int SwayBarArmLength { get; set; }
                    public Single LeftBarEndClearance { get; set; }
                    public bool AttachLeftSide { get; set; }
                    public Single TapeConfiguration { get; set; }
                }
                public class ChassisRear
                {
                    //Rear:
                    // FuelFillTo: 60.5 L
                    // RearEndRatio: 4.89
                    public Single FuelFillTo { get; set; }
                    public Single RearEndRatio { get; set; }
                }
                public class FrontCorner
                {
                    //LeftFront:
                    // CornerWeight: 3395 N
                    // RideHeight: 77 mm
                    // ShockDeflection: 75.9 mm 155.9 mm
                    // SpringDeflection: 90.4 mm 188.9 mm
                    // SpringPerchOffset: 72 mm
                    // SpringRate: 44 N/mm
                    // Packer: 61.9 mm shim
                    // BumpStiffness: +6 clicks
                    // ReboundStiffness: +8 clicks
                    // Camber: +4.2 deg
                    // Caster: +4.0 deg
                    public int CornerWeight { get; set; }
                    public Single RideHeight { get; set; }
                    public Single SpringPerchOffset { get; set; }
                    public int SpringRate { get; set; }
                    public int BumpStiffness { get; set; }
                    public int ReboundStiffness { get; set; }
                    public Single Packer { get; set; }
                    public Single Camber { get; set; }
                    public Single Caster { get; set; }
                    public DeflectionSetting ShockDeflection { get; set; }
                    public DeflectionSetting SpringDeflection { get; set; }
                }
                public class DeflectionSetting
                {
                    public Single Position { get; set; }
                    public Single Max { get; set; }
                }
                public class RearCorner
                {
                    //LeftRear:
                    // CornerWeight: 3653 N
                    // RideHeight: 78 mm
                    // SpringPerchOffset: 141 mm
                    // SpringRate: 53 N/mm
                    // BumpStiffness: +4 clicks
                    // ReboundStiffness: +15 clicks

                    // Packer: 0.0 mm shim
                    // ShockDeflection: 47.4 mm 142.0 mm
                    // SpringDeflection: 69.4 mm 183.5 mm

                    // TrackBarHeight: +235 mm
                    // TrailingArmMount: bottom
                    public int CornerWeight { get; set; }
                    public Single RideHeight { get; set; }
                    public Single SpringPerchOffset { get; set; }
                    public int SpringRate { get; set; }
                    public int BumpStiffness { get; set; }
                    public int ReboundStiffness { get; set; }
                    public int TrackBarHeight { get; set; }
                    public Single TruckArmPreload { get; set; }
                    public string TruckArmMount { get; set; }
                    public Single Packer { get; set; }
                    public DeflectionSetting ShockDeflection { get; set; }
                    public DeflectionSetting SpringDeflection { get; set; }

                    public RearCorner()
                    {
                        // Default for left side
                        TruckArmPreload = 0;
                    }
                }
            }
        }
        #endregion
    }
}
