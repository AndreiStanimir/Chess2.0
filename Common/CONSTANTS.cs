namespace Chess20.Common
{
    public static class CONSTANTS
    {
        public const int MAX_TIME = 10000;
        public const int MAX_INCREMENT = 60;
        public const int MAX_X = 8;
        public const int MAX_Y = 8;

        public static bool IsInside(int y, int x)
        {
            return 0 <= x && x <= MAX_X && 0 <= y && y <= MAX_Y;
        }
    }
}