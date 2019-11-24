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
                int year = int.Parse(Console.ReadLine());

                Console.WriteLine(GetBooksNotReleasedIn(db, year));
            }
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => new { b.Title })
                .ToList();

            foreach (var b in books)
            {
                sb.AppendLine(b.Title);
            }

            return sb.ToString().TrimEnd();
        }
    }
}