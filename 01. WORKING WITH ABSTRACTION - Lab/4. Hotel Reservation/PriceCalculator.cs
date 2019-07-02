using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal GetTotalPrice(decimal price, int days, Season season, Discount discount)
        {
            int currentSeason = (int)season;

            decimal total = price * days * currentSeason;

            decimal currentDiscount = (int)discount;

            decimal result = total * (100 - currentDiscount) / 100;

            return result;
        }
    }
}
