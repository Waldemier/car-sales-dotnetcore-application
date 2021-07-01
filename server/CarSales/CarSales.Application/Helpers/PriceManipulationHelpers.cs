using System;

namespace CarSales.Application.Helpers
{
    public static class PriceManipulationHelpers
    {
        public static double GetPriceFromStringFormat(this string price)
        {
            return Double.Parse(price.Replace("$", "").Replace(" ", ""));   
        }
    }
}