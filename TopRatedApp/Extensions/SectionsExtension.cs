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
                double x;
                var textSize = section.GetTexSize();
                var textWidth = Convert.ToInt32(textSize.Width);
                var textHeight = Convert.ToInt32(textSize.Height);
                var sectionPosition = section.GetPosition(i, count);
                switch (sectionPosition)
                {
                    case SectionPosition.Left:
                        w = pBr + textWidth + pMd;
                        x = pBr + badgeWidth + textWidth / 2.0;
                        break;
                    case SectionPosition.Middle:
                        w = pMd + textWidth + pMd;
                        x = pMd + badgeWidth + textWidth / 2.0;
                        break;
                    case SectionPosition.Right:
                        w = pMd + textWidth + pBr;
                        x = pMd + badgeWidth + textWidth / 2.0;
                        break;
                    case SectionPosition.OneSectionOnly:
                        w = pBr + textWidth + pBr;
                        x = pBr + badgeWidth + textWidth / 2.0;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                var h = pTp + textHeight + pBt;
                var y = pTp  + textHeight / 2;
                var sectionPath = PathHelper.GetSectionPath(sectionPosition, badgeWidth, 0, w, h, r);

                //Debug.WriteLine($"tw: {textWidth}, pBr: {pBr}, pMd: {pMd}, pTp: {pTp}, pBt: {pBt}, " +
                //                $"i: {i}, c: {count}, x: {x}, y: {y}, w: {w}, h: {h}, bW: {badgeWidth}, bH: {badgeHeight}");

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