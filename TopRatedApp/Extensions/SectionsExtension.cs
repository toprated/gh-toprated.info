using System;
using System.Diagnostics;
using TopRatedApp.Common;
using TopRatedApp.Enums;
using TopRatedApp.Helpers;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Extensions
{
    public static class SectionsExtension
    {
        public static Section[] GetFullSections(this Section[] sections, IBadgeStyle badgeStyle)
        {
            var count = sections.Length;
            var pBr = badgeStyle.PaddingBorders;
            var pMd = badgeStyle.PaddingMiddle;
            var pTp = badgeStyle.PaddingTop;
            var pBt = badgeStyle.PaddingBottom;
            var r = badgeStyle.Radius;
            var badgeWidth = 0.0;
            var badgeHeight = 0.0;
            for (var i = 0; i < count; i++)
            {
                var section = sections[i];
                double w;
                var textWidth = section.GetTextWidth();
                var textHeight = section.GetTextHeight();
                var sectionPosition = section.GetPosition(i, count);
                switch (sectionPosition)
                {
                    case SectionPosition.Left:
                        w = pBr + textWidth + pMd;
                        break;
                    case SectionPosition.Middle:
                        w = pMd + textWidth + pMd;
                        break;
                    case SectionPosition.Right:
                        w = pMd + textWidth + pBr;
                        break;
                    case SectionPosition.OneSectionOnly:
                        w = pBr + textWidth + pBr;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                var h = pTp + textHeight + pBt;
                var x = badgeWidth + w / 2;
                var y = h / 2;
                var sectionPath = PathHelper.GetSectionPath(sectionPosition, badgeWidth, 0, w, h, r);

                Debug.WriteLine($"i: {i}, c: {count}, x: {x}, y: {y}, w: {w}, h: {h}, bW: {badgeWidth}, bH: {badgeHeight}");

                sections[i].H = h;
                sections[i].W = w;
                sections[i].X = x;
                sections[i].Y = y;
                sections[i].Path = sectionPath;

                badgeWidth += w;
                if (badgeHeight < h)
                {
                    badgeHeight = h;
                }
            }
            return sections;
        }
    }
}