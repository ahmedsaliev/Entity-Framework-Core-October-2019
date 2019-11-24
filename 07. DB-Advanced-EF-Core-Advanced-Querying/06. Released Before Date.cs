namespace BookShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BookShop.Models;
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                string year = Console.ReadLine();

                Console.WriteLine(GetBooksReleasedBefore(db, year));
            }
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)

        {
            StringBuilder sb = new StringBuilder();

            DateTime releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context
                .Books
                .Where(b => b.ReleaseDate < releaseDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new { b.Title, b.EditionType, b.Price })
                .ToList();

            foreach (var b in books)
            {
                string line = $"{b.Title} - {b.EditionType} - ${b.Price:F2}";
                sb.AppendLine(line); ;
            }

            return sb.ToString().TrimEnd();
        }
    }
}