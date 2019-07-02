using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservation
{
    public enum Season
    {
        Autumn = 1,
        Spring,
        Winter,
        Summer
    }

    public enum Discount
    {
        None,
        SecondVisit = 10,
        VIP = 20
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();

            decimal price = decimal.Parse(input[0]);

            int days = int.Parse(input[1]);

            Season season = (Season)Enum.Parse(typeof(Season), input[2]);

            Discount discount = Discount.None;

            if (input.Count == 4)
            {
                discount = (Discount)Enum.Parse(typeof(Discount), input[3]);
            }

            Console.WriteLine($"{(PriceCalculator.GetTotalPrice(price, days, season, discount)):F2}");
            
        }
    }
}
