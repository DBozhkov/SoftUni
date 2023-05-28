namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetMostRecentBooks(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var bookTitles = context.Books
                                .Where(bt => bt.AgeRestriction.ToString().Equals(command, StringComparison.OrdinalIgnoreCase))
                                .OrderBy(bt => bt)
                                .Select(x => x.Title)
                                .ToList();

            return string.Join(Environment.NewLine, bookTitles);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                                    .Where(b => b.EditionType.ToString() == "Gold" && b.Copies < 5000)
                                    .OrderBy(b => b.BookId
)
                                    .Select(b => b.Title)
                                    .ToList();

            return string.Join(Environment.NewLine, goldenBooks);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            var booksPrice = context.Books
                                    .Where(b => b.Price > 40)
                                    .Select(b => new
                                    {
                                        b.Title,
                                        b.Price
                                    })
                                    .OrderByDescending(b => b.Price)
                                    .ToList();

            foreach (var book in booksPrice)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                               .Where(b => b.ReleaseDate.Value.Year != year)
                               .OrderBy(b => b.BookId)
                               .Select(b => b.Title)
                               .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> listOfCategories = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            var list = new List<string>();

            foreach (var category in listOfCategories)
            {
                var books = context.Books
                                   .Where(b => b.BookCategories.Any(bc => bc.Category.Name.ToLower() == category))
                                   .Select(b => b.Title)
                                   .ToList();

                list.AddRange(books);
            }

            var finalList = list.OrderBy(bn => bn).ToList();

            return string.Join(Environment.NewLine, finalList);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime convDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books
                .Where(b => b.ReleaseDate < convDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
                .ToList();

            return String.Join(Environment.NewLine, books);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNames = context.Authors
                                     .Where(x => x.FirstName.EndsWith(input, StringComparison.OrdinalIgnoreCase))
                                     .Select(x => $"{x.FirstName} {x.LastName}")
                                     .OrderBy(x => x)
                                     .ToList();

            return string.Join(Environment.NewLine, authorNames);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitles = context.Books
                         .Where(x => x.Title.Contains(input, StringComparison.OrdinalIgnoreCase))
                         .Select(x => x.Title)
                         .OrderBy(x => x)
                         .ToList();

            return string.Join(Environment.NewLine, bookTitles);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var bookAuthors = context.Books
                                     .OrderBy(x => x.BookId)
                                     .Where(x => x.Author.LastName.StartsWith(input, StringComparison.OrdinalIgnoreCase))
                                     .Select(x => $"{x.Title} ({x.Author.FirstName} {x.Author.LastName})")
                                     .ToList();

            return string.Join(Environment.NewLine, bookAuthors);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context.Books
                                    .Where(x => x.Title.Length > lengthCheck)
                                    .Count();

            return booksCount;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            var authorBooksCount = context.Authors
                                          .Select(a => new
                                          {
                                              FullName = $"{a.FirstName} {a.LastName}",
                                              BookCopies = a.Books
                                                            .Select(x => x.Copies)
                                                            .Sum()
                                          })
                                          .ToList()
                                          .OrderByDescending(x => x.BookCopies)
                                          .ToList();

            foreach (var authorBook in authorBooksCount)
            {
                sb.AppendLine($"{authorBook.FullName} - {authorBook.BookCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            var categoryProfit = context.Categories
                                        .Select(x => new
                                        {
                                            x.Name,
                                            TotalProfit = x.CategoryBooks
                                                      .Select(cb => cb.Book.Price * cb.Book.Copies)
                                                      .Sum()
                                        })
                                        .OrderByDescending(x => x.TotalProfit)
                                        .ThenBy(x => x.Name)
                                        .ToList();

            foreach (var cp in categoryProfit)
            {
                sb.AppendLine($"{cp.Name} ${cp.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var recentBoks = context.Categories
                                    .Select(x => new
                                    {
                                        x.Name,
                                        TopBooks = x.CategoryBooks
                                                    .OrderByDescending(b => b.Book.ReleaseDate)
                                                    .Select(cb => new
                                                    {
                                                        cb.Book.Title,
                                                        cb.Book.ReleaseDate
                                                    })
                                                    .Take(3)
                                    })
                                    .OrderBy(x => x.Name)
                                    .ToList();

            foreach (var book in recentBoks)
            {
                sb.AppendLine($"--{book.Name}");
                foreach (var tb in book.TopBooks)
                {
                    sb.AppendLine($"{tb.Title} ({tb.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var increasedPrice = context.Books
                                        .Where(x => x.ReleaseDate.Value.Year < 2010);

            foreach (var book in increasedPrice)
            {
                book.Price += 5m;
            }
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                        .Where(b => b.Copies < 4200)
                        .ToArray();

            var removedBooks = books.Length;

            context.Books.RemoveRange(books);

            return removedBooks;
        }
    }
}


