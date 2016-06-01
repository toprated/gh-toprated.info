using System;
using TopRatedApp.Enums;

namespace TopRatedApp.Helpers
{
    public static class PathHelper
    {
        private static string Point(double x, double y)
        {
            return x + " " + y + " ";
        }

        private static string GetRoundedRectPath(double x, double y, double w, double h, double r1, double r2, double r3, double r4)
        {
            var path = $"M{ Point(x + r1, y)}"; //A
            path += $"L{Point(x + w - r2, y)}Q{Point(x + w, y)}{Point(x + w, y + r2)}"; //B
            path += $"L{Point(x + w, y + h - r3)}Q{Point(x + w, y + h)}{Point(x + w - r3, y + h)}"; //C
            path += $"L{Point(x + r4, y + h)}Q{Point(x, y + h)}{Point(x, y + h - r4)}"; //D
            path += $"L{Point(x, y + r1)}Q{Point(x, y)}{Point(x + r1, y)}"; //A
            path += "Z";

            return path;
        }

        public static string GetSimpleRoundedRectPath(double x, double y, double w, double h, double r)
        {
            return GetRoundedRectPath(x, y, w, h, r, r, r, r);
        }

        public static string GetSectionPath(SectionPosition position, double x, double y, double w, double h, double r)
        {
            switch (position)
            {
                case SectionPosition.Left:           return GetRoundedRectPath(x, y, w + 1, h, r, 0, 0, r);
                case SectionPosition.Middle:         return GetRoundedRectPath(x, y, w + 1, h, 0, 0, 0, 0);
                case SectionPosition.Right:          return GetRoundedRectPath(x, y, w, h, 0, r, r, 0);
                case SectionPosition.OneSectionOnly: return GetRoundedRectPath(x, y, w, h, r, r, r, r);
                default:
                    throw new ArgumentOutOfRangeException(nameof(position), position, null);
            }
        }
    }
}