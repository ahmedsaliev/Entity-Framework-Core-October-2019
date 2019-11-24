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
                Console.WriteLine(GetMostRecentBooks(db));
            }
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categoriesAndMostRecentBooks = context
                .Categories
                .Select(c => new
                {
                    categoryName = c.Name,
                    categoryRecentBooks = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Take(3)
                        .Select(cb => new
                    {
                        BookTitle = cb.Book.Title,
                        BookRelease = cb.Book.ReleaseDate.Value.Year
                    })
                    .ToList()
                })
                .OrderBy(c => c.categoryName)
                .ToList();

            foreach (var c in categoriesAndMostRecentBooks)
            {
                sb.AppendLine($"--{c.categoryName}");

                foreach (var b in c.categoryRecentBooks)
                {
                    sb.AppendLine($"{b.BookTitle} ({b.BookRelease})");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}