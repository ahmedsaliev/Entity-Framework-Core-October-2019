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
                Console.WriteLine(CountCopiesByAuthor(db));
            }
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context
                .Authors
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    BookCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.BookCopies)
                .ToList();

            foreach (var a in authors)
            {
                sb.AppendLine($"{a.Name} - {a.BookCopies}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}