using System;

namespace Braspag.Sdk.Common
{
    public class UnixTimeStampConverter
    {
        public static DateTime ToDateTime(string unixTimeStamp)
        {
            var success = double.TryParse(unixTimeStamp, out var unix);

            if (success == false)
                throw new ArgumentException("UnixTimeStamp must be a valid value");

            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unix).ToLocalTime();
        }

        public static string ToUnixTimeStamp(DateTime date)
        {
            var unixTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            return unixTimestamp.ToString();
        }
    }
}