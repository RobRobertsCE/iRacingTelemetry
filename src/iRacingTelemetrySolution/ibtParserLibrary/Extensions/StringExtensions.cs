using System;

namespace iRacing.TelemetryParser.Helpers
{
    public static class StringExtensions
    {
        public static byte[] ToByteArray(this string self)
        {
            char[] charArr = self.ToCharArray();
            byte[] bytes = new byte[charArr.Length];
            for (int i = 0; i < charArr.Length; i++)
            {
                byte current = Convert.ToByte(charArr[i]);
                bytes[i] = current;
            }

            return bytes;
        }
    }
}