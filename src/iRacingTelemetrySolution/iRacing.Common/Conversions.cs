using System;

namespace iRacing
{
    public static class Conversions
    {
        #region constants
        public const Single Kpa_Psi = 0.14503773773020923F;
        public const Single Liters_Gallons = 0.264172F;
        public const Single Newtons_Pounds = 0.224809F;
        public const Single NewtonMeters_PoundsInch = 0.00014503773773022F;
        public const Single NewtonMillimeters_PoundsInch = 5.71014716277F;
        public const Single MM_Inch = 0.0393700787F;
        #endregion

        #region public
        public static Single GetValue(string setupValue)
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
        public static Single KpaToPsi(Single kpa)
        {
            return kpa * Kpa_Psi;
        }
        public static Single CelciusToFarenheit(Single celcius)
        {
            return (float)(((9.0 / 5.0) * celcius) + 32);
        }
        public static Single LitersToGallons(Single liters)
        {
            return liters * Liters_Gallons;
        }
        public static Single NewtonsToPounds(Single newtons)
        {
            return newtons * Newtons_Pounds;
        }
        public static Single NmmToLbsIn(Single Nmm)
        {
            return Nmm * NewtonMillimeters_PoundsInch;
        }
        public static Single NmToLbsIn(Single Nm)
        {
            return Nm * NewtonMeters_PoundsInch;
        }
        public static Single MMToInches(Single mm)
        {
            return mm * MM_Inch;
        }

        // -2/16 in, -.125 out
        public static double FractionToDouble(string data)
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
        #endregion
    }
}
