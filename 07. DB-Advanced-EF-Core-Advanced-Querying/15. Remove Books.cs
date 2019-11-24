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
                Console.WriteLine(RemoveBooks(db));
            }
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksForDelete = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.RemoveRange(booksForDelete);

            context.SaveChanges();

            return booksForDelete.Count;
        }
    }
}