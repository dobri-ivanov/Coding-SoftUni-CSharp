namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.Extensions.Primitives;
    using System.Text;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();

            //DbInitializer.ResetDatabase(db);

            string input = Console.ReadLine();
            Console.WriteLine(GetAuthorNamesEndingIn(db, input));
        }

        //Problem 2
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            string[] bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, bookTitles);
        }

        //Problem 3
        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] bookTitles = context.Books
                .Where(b => b.EditionType == EditionType.Gold)
                .Where(b => b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, bookTitles);
        }

        //Problem 4
        public static string GetBooksByPrice(BookShopContext context)
        {
            string[] titlesAndPricesOfBooks = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => (b.Title + " - $" + b.Price.ToString("f2")).ToString())
                .ToArray();

            return String.Join(Environment.NewLine, titlesAndPricesOfBooks);
        }

        //Problem 5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            string[] bookTitles = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, bookTitles);
        }

        //Problem 6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            string[] booksTitles = context.BooksCategories
                .Where(bc => categories.Contains(bc.Category.Name.ToLower()))
                .OrderBy(bc => bc.Book.Title)
                .Select(bc => bc.Book.Title)
                .ToArray();

            return String.Join(Environment.NewLine, booksTitles);
        }

        //Problem 7
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {

            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var booksInfo = context.Books
                .Where(b => b.ReleaseDate < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
                .ToArray();

            return String.Join(Environment.NewLine, booksInfo);
        }

        //Problem 8
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            string[] authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(name => name)
                .ToArray();

            return String.Join(Environment.NewLine, authors);
        }
    }
}


