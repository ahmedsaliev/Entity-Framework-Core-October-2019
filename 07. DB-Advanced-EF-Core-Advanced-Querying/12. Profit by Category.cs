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
                Console.WriteLine(GetTotalProfitByCategory(db));
            }
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    totalProfit = c.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price)
                })
                .OrderByDescending(c => c.totalProfit)
                .ThenBy(c => c.Name)
                .ToList();

            foreach (var c in categories)
            {
                sb.AppendLine($"{c.Name} ${c.totalProfit:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}