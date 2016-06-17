using System;
using System.Diagnostics;
using TopRatedApp.Common.BadgeClasses;
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
            var pL = badgeStyle.BadgeGeometry.Padding.BorderLeft;
            var pR = badgeStyle.BadgeGeometry.Padding.BorderRight;
            var pMd = badgeStyle.BadgeGeometry.Padding.Middle;
            var pTp = badgeStyle.BadgeGeometry.Padding.Top;
            var pBt = badgeStyle.BadgeGeometry.Padding.Bottom;
            var r = badgeStyle.BadgeGeometry.Radius;
            var badgeWidth = 0.0;
            var badgeHeight = 0.0;
            for (var i = 0; i < count; i++)
            {
                var section = sections[i];
                double w;
                double x;
                var textSize = section.GetTexSize();
                var tW = section.SectionType.Equals(SectionType.Icon) ? section.W - pL - pMd : Convert.ToInt32(textSize.Width);
                var tH = section.SectionType.Equals(SectionType.Icon) ? section.H - pTp - pBt : Convert.ToInt32(textSize.Height);
                var sectionPosition = section.GetPosition(i, count);
                switch (sectionPosition)
                {
                    case SectionPosition.Left:
                        w = pL + tW + pMd;
                        x = pL + badgeWidth + tW / 2.0;
                        break;
                    case SectionPosition.Middle:
                        w = pMd + tW + pMd;
                        x = pMd + badgeWidth + tW / 2.0;
                        break;
                    case SectionPosition.Right:
                        w = pMd + tW + pR;
                        x = pMd + badgeWidth + tW / 2.0;
                        break;
                    case SectionPosition.OneSectionOnly:
                        w = pL + tW + pR;
                        x = pL + badgeWidth + tW / 2.0;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                var h = pTp + tH + pBt;
                var y = pTp  + tH;
                var sectionPath = PathHelper.GetSectionPath(sectionPosition, badgeWidth, 0, w, h, r);

                sections[i].H = h;
                sections[i].W = w;
                sections[i].X = x;
                sections[i].Y = y;
                sections[i].Tw = tW;
                sections[i].Th = tH;
                sections[i].Path = sectionPath;

                Debug.WriteLine($"h:{h}, w:{w}, x:{x}, y:{y}, th:{tH}, tw:{tW}");

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