using System;

namespace Assets.Scripts
{
    public static class Utilities
    {
        public static string Format(this long number)
        {
            return number.ToString("G");
        }
        
        public static long GetCurrentTime()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
    }
}
