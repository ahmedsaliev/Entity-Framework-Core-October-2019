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

                Console.WriteLine(GetBooksByCategory(db, input));
            }
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<Book> books = new List<Book>();

            string[] categories = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.ToLower())
                    .ToArray();

            foreach (var c in categories)
            {
                var booksInCategory = context.Books
                .Where(b => b.BookCategories
                    .Select(bc => new { bc.Category.Name })
                    .Any(ca => ca.Name.ToLower() == c))
                .ToList();

                books.AddRange(booksInCategory);
            }

            var orderedBooks = books
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();
            
            return String.Join(Environment.NewLine, orderedBooks);
        }
    }
}