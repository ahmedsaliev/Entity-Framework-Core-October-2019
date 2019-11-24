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
                int lengthCheck = int.Parse(Console.ReadLine());

                Console.WriteLine($"There are {CountBooks(db, lengthCheck)} books with longer title than {lengthCheck} symbols");
            }
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return booksCount;
        }
    }
}