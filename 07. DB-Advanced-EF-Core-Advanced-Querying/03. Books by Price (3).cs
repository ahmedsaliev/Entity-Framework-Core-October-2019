namespace BookShop
{
    using System;
    using System.Linq;
    using System.Text;

    using Data;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                Console.WriteLine(GetBooksByPrice(db));
            }
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new { b.Title, b.Price })
                .ToList();

            foreach (var b in books)
            {
                string line = $"{b.Title} - ${b.Price:F2}";
                sb.AppendLine(line);
            }

            return sb.ToString().TrimEnd();
        }
    }
}