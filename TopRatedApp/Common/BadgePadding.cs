using TopRatedApp.Interfaces;

namespace TopRatedApp.Common
{
    public class BadgePadding : IBadgePadding
    {
        public int Borders { get; set; }
        public int Middle { get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }

        public BadgePadding(int borders, int middle, int top, int bottom)
        {
            Borders = borders;
            Middle = middle;
            Top = top;
            Bottom = bottom;
        }
    }
}