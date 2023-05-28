namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(ImportBooksDTO[]), new XmlRootAttribute("Books"));


            using (StringReader sr = new StringReader(xmlString))
            {

                var books = (ImportBooksDTO[])xmlSerializer.Deserialize(sr);

                var finalBooks = new List<Book>();

                foreach (var book in books)
                {
                    if (!IsValid(book))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime publishedOn;
                    var parser = DateTime.TryParseExact(book.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out publishedOn);

                    if (!IsValid(publishedOn))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var validBook = new Book
                    {
                        Name = book.Name,
                        Price = book.Price,
                        Genre = (Genre)book.Genre,
                        Pages = book.Pages,
                        PublishedOn = publishedOn,
                    };

                    finalBooks.Add(validBook);
                    sb.AppendLine(String.Format(SuccessfullyImportedBook, validBook.Name, validBook.Price));
                }
                context.Books.AddRange(finalBooks);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var authors = JsonConvert.DeserializeObject<List<ImportAuthorDTO>>(jsonString);
            var existingAuthors = new List<Author>();

            foreach (var authorDto in authors)
            {
                if (!IsValid(authorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (existingAuthors.Any(x => x.Email == authorDto.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Author author = new Author
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Email = authorDto.Email,
                    Phone = authorDto.Phone,
                };

                foreach (var bookDto in authorDto.Books)
                {
                    if (!bookDto.BookId.HasValue)
                    {
                        continue;
                    }

                    var book = context.Books
                                      .FirstOrDefault(x => x.Id == bookDto.BookId);

                    if (book == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = author,
                        Book = book,
                    });

                    if (author.AuthorsBooks.Count == 0)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    existingAuthors.Add(author);
                    sb.AppendLine(String.Format(SuccessfullyImportedAuthor, (author.FirstName + ' ' + author.LastName), author.AuthorsBooks.Count));
                }

            }
            context.Authors.AddRange(existingAuthors);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}