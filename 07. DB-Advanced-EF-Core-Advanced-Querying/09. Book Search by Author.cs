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
                string input = Console.ReadLine();

                Console.WriteLine(GetBooksByAuthor(db, input));
            }
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)

        {
            StringBuilder sb = new StringBuilder();

            var booksAndAuthors = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    Author = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .ToList();

            foreach (var b in booksAndAuthors)
            {
                sb.AppendLine($"{b.Title} ({b.Author})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}