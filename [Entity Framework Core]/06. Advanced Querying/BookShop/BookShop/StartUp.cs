namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Primitives;
    using System.Text;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();

            DbInitializer.ResetDatabase(db);

            //string input = Console.ReadLine();
            //int input = int.Parse(Console.ReadLine());

            //Console.WriteLine(CountBooks(db, input));
            Console.WriteLine(GetMostRecentBooks(db));
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

        //Problem 9
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string[] booksTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(title => title)
                .ToArray();

            return String.Join(Environment.NewLine, booksTitles);
        }

        //Problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            string[] booksInfo = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();

            return String.Join(Environment.NewLine, booksInfo);
        }

        //Problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int countOfBooks = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToArray()
                .Count();

            return countOfBooks;
        }

        //Problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            string[] countCopiesByAuthor = context
                .Authors
                .OrderByDescending(a => a.Books.Sum(b => b.Copies))
                .Select(a => $"{a.FirstName} {a.LastName} - {a.Books.Sum(b => b.Copies)}")
                .ToArray();

            return String.Join(Environment.NewLine, countCopiesByAuthor);
        }

        //Problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            string[] info = context.Categories
                .OrderByDescending(c => c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price))
                .ThenBy(c => c.Name)
                .Select(c => $"{c.Name} ${c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price):f2}")
                .ToArray();

            return String.Join(Environment.NewLine, info);

        }

        //Problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var info = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks
                            .OrderByDescending(cb => cb.Book.ReleaseDate)
                            .Select(cb => $"{cb.Book.Title} ({cb.Book.ReleaseDate.Value.Year})")
                            .Take(3)
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var i in info)
            {
                sb.AppendLine($"--{i.CategoryName}");

                foreach (var item in i.Books)
                {
                    sb.AppendLine(String.Join(Environment.NewLine, item));
                }
            }

            return sb.ToString().TrimEnd();
                
        }
        //Problem 15
        public static void IncreasePrices(BookShopContext context)
        {
            Book[] booksToBeUpdated = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var b in booksToBeUpdated)
            {
                b.Price += 5;
            }
            context.SaveChanges();
        }

        //Problem 16
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToBeRemoved = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.Books.RemoveRange(booksToBeRemoved);
            context.SaveChanges();

            return booksToBeRemoved.Count();
        }
    }
}


