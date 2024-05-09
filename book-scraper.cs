using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace BookScraper
{
    public class BookScraper
    {
        static void Main()
        {
            string baseUrl = "https://www.goodreads.com";

            HtmlWeb web = new();
            var document = web.Load($"{baseUrl}/shelf/show/fantasy");

            List<Book> fantasyBooks = [];

            var bookHTMLElements = document.DocumentNode.QuerySelectorAll(".elementList");

            foreach (var bookElement in bookHTMLElements)
            {
                Book currentBook = new()
                {
                    Title = HtmlEntity.DeEntitize(bookElement.QuerySelector(".bookTitle").InnerText),
                    AuthorFullName = HtmlEntity.DeEntitize(bookElement.QuerySelector(".authorName").InnerText),
                    Url = HtmlEntity.DeEntitize(bookElement.QuerySelector(".bookTItle").Attributes["href"].Value)
                };

                fantasyBooks.Add(currentBook);

                Console.WriteLine($"{currentBook.Title}");
                Console.WriteLine($"by {currentBook.AuthorFullName}");
                Console.WriteLine($"{currentBook.Url}");
            }

            Console.WriteLine($"{fantasyBooks.Count}");


            // HtmlWeb currentBookPage = new();
            // var currentBookDoc = web.Load($"{baseUrl}{url}");
            // var currentBookPageElement = currentBookDoc.DocumentNode.QuerySelectorAll(".BookPage__mainContent");

            // foreach (var mainContent in currentBookPageElement)
            // {
            //     var pageCount = HtmlEntity.DeEntitize(mainContent.QuerySelector(".pagesFormat").InnerText);
            //     Console.WriteLine($"{pageCount}");
            // }


        }

    }
}
