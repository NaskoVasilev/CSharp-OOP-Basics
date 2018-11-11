using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal CalculatePrice(decimal pricePerDay , int daysCount,
            int seasonNumber , int discount)
        {
            return (pricePerDay * daysCount * (int)seasonNumber) * (1 - (decimal)discount / 100);
        }
    }
}
