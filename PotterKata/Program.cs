using System;
using System.Collections.Generic;

namespace PotterKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type the number of copies of Harry the English Wizard vol.1 you would like to buy, and then press Enter");
            var book1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Type the number of copies of Harry the English Wizard vol.2 you would like to buy, and then press Enter");
            var book2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Type the number of copies of Harry the English Wizard vol.3 you would like to buy, and then press Enter");
            var book3 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Type the number of copies of Harry the English Wizard vol.4 you would like to buy, and then press Enter");
            var book4 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Type the number of copies of Harry the English Wizard vol.5 you would like to buy, and then press Enter");
            var book5 = Convert.ToInt32(Console.ReadLine());

            List<int> booksSelected = new();
            AddBooks(book1, booksSelected, 1);
            AddBooks(book2, booksSelected, 2);
            AddBooks(book3, booksSelected, 3);
            AddBooks(book4, booksSelected, 4);
            AddBooks(book5, booksSelected, 5);

            var result = PricingService.CalcPrice(booksSelected.ToArray());

            Console.WriteLine($"Total price: £{result}");
        }

        private static void AddBooks(int book, List<int> booksSelected, int bookVolume)
        {
            for (int i = 0; i < book; i++)
            {
                booksSelected.Add(bookVolume);
            }
        }
    }
}
