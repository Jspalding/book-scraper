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
                var title = HtmlEntity.DeEntitize(bookElement.QuerySelector(".bookTitle").InnerText);
                Console.WriteLine($"{title}");

                var author = HtmlEntity.DeEntitize(bookElement.QuerySelector(".authorName").InnerText);
                Console.WriteLine($"by {author}");

                var url = HtmlEntity.DeEntitize(bookElement.QuerySelector(".bookTItle").Attributes["href"].Value);
                Console.WriteLine($"{url}");
            }


        }

    }
}
