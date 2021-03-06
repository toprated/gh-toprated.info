﻿using TopRatedApp.Extensions;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.TopRatedCategories
{
    public class Category : ICategory
    {
        public string PercentageString => Percentage.ToAttrData();
        public double Percentage { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public int Count { get; set; }

        public Category(double percentage, int count = 0, int starsFrom = 0, int starsTo = 0)
        {
            Percentage = percentage;
            From = starsFrom;
            To = starsTo;
            Count = count;
        }
    }
}