using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.BadgeClasses
{
    public class BadgePadding : IBadgePadding
    {
        public int Borders { get; set; }
        public int BorderLeft { get; set; }
        public int BorderRight { get; set; }
        public int Middle { get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }

        public BadgePadding(int borders, int left, int right, int middle, int top, int bottom)
        {
            Borders = borders;
            BorderLeft = left;
            BorderRight = right;
            Middle = middle;
            Top = top;
            Bottom = bottom;
        }
    }
}