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

                Console.WriteLine(GetAuthorNamesEndingIn(db, input));
            }
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)

        {
            var authors = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(a => a)
                .ToList();

            return String.Join(Environment.NewLine, authors);
        }
    }
}