﻿using System.Drawing;
using TopRatedApp.Common;
using TopRatedApp.Enums;

namespace TopRatedApp.Extensions
{
    public static class SectionExtensions
    {
        public static SizeF GetTexSize(this Section section)
        {
            return section.SectionStyle.FontStyle.GetTextSize(section.Text);
        }
        
        public static SectionPosition GetPosition(this Section section, int index, int count)
        {
            if (index == 0)
            {
                return SectionPosition.Left;
            }
            if (index == count - 1)
            {
                return SectionPosition.Right;
            }
            if (index == 0 && count == 1)
            {
                return SectionPosition.OneSectionOnly;
            }
            return SectionPosition.Middle;
        }
    }
}