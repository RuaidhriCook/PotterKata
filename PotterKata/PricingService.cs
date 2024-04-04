using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class PricingService
    {
        private const decimal standardBookPrice = 8.0m;
        private static readonly Dictionary<int, decimal> discountTiers = new()
        {
            { 1, 0.0m },
            { 2, 0.05m },
            { 3, 0.10m },
            { 4, 0.20m },
            { 5, 0.25m }
        };

        public static decimal CalcPrice(int[] booksSelected)
        {
            Console.WriteLine("Checking books selected are valid for calculation...");
            if (booksSelected == null || booksSelected.Length == 0)
            {
                Console.WriteLine("Array of Books in null or empty - no calculation to perform");
                return 0.0m;
            }                

            Console.WriteLine("Getting total count for each book volume...");
            Dictionary<int, int> booksVolumesToBePriced = GetBookVolumeCounts(booksSelected);

            decimal priceTotal = 0.0m;

            Console.WriteLine("Adding Books to be priced to price total...");
            while (booksVolumesToBePriced.Values.Sum() > 0)
            {
                Console.WriteLine("Getting total of different book volumes (with book count over zero)...");
                int differentBooksCount = 
                    booksVolumesToBePriced.Values.Count(bookVolumeCount => bookVolumeCount > 0);

                Console.WriteLine("Getting discount rate...");
                decimal discountRate = discountTiers[differentBooksCount];

                Console.WriteLine("Getting price with discount for each book to be priced...");
                for (int i = 0; i < booksVolumesToBePriced.Count; i++)
                {
                    Console.WriteLine($"Checking book volume {i+1} has count above zero...");
                    if (booksVolumesToBePriced[i + 1] > 0)
                    {
                        Console.WriteLine("Adding price of the book to the total");
                        priceTotal += GetPriceWithDiscount(discountRate);

                        Console.WriteLine("Removing book from queue to be priced");
                        booksVolumesToBePriced[i + 1]--;
                    }
                }
            }

            return priceTotal;
        }

        private static decimal GetPriceWithDiscount(decimal discountRate)
        {
            return standardBookPrice * (1.0m - discountRate);
        }

        private static Dictionary<int, int> GetBookVolumeCounts(int[] booksSelected)
        {
            Dictionary<int, int> bookVolumeCounts = new()
            {
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 },
                { 5, 0 },
            };

            booksSelected.ToList()
                .ForEach(book => bookVolumeCounts[book]++);

            return bookVolumeCounts;
        }
    }

}
