namespace tomodachi.Engine
{
    public static class WorldClock
    {
        public static DateTime Now => DateTime.Now;
        public static bool IsDay
        {
            get
            {
                int hour = Now.Hour;
                return hour >= 6 && hour < 20;
            }
        }
        public static bool IsNight => !IsDay;
    }
}