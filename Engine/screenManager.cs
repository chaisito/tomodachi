using System.Windows;

namespace tomodachi.Engine
{
    public static class ScreenManager
    {
        public static Rect WorkArea => SystemParameters.WorkArea;

        public static double Left => WorkArea.Left;

        public static double Right => WorkArea.Right;

        public static double Top => WorkArea.Top;

        public static double Bottom => WorkArea.Bottom;

        public static double GroundY(double spriteHeight)
            => Bottom - spriteHeight;
    }
}