using System;

namespace HotelReservation
{
    class HotelReservation
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split();
            decimal pricePerDay = decimal.Parse(data[0]);
            int daysCount = int.Parse(data[1]);
            string season = data[2];
            int discount = 0;
            if (data.Length > 3)
            {
                discount = GetDiscount(data[3]);
            }

            int seasonNumber = GetSeasonNumber(season);

            decimal price = PriceCalculator.CalculatePrice(pricePerDay, daysCount, seasonNumber, discount);
            Console.WriteLine($"{price:F2}");
        }

        private static int GetSeasonNumber(string season)
        {
            switch (season)
            {
                case "Autumn":
                    return (int)Season.Autumn;
                case "Winter":
                    return (int)Season.Winter;
                case "Summer":
                    return (int)Season.Summer;
                case "Spring":
                    return (int)Season.Spring;
            }
            return 1;
        }

        private static int GetDiscount(string discountType)
        {
            switch (discountType)
            {
                case "None":
                    return 0;
                case "SecondVisit":
                    return (int)Discount.SecondVisit;
                case "VIP":
                    return (int)Discount.VIP;
            }
            return 0;
        }
    }

    public enum Season
    {
        Autumn = 1,
        Spring,
        Winter,
        Summer
    }

    public enum Discount
    {
        None = 0,
        SecondVisit = 10,
        VIP = 20
    }
}
