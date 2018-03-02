using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

class IntersectionOfCircles
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        var listOfBooks = new List<Book>();
        for (int i = 0; i < count; i++)
        {
            string[] inputLine = Console.ReadLine().Split().ToArray();
            string currentTitle = inputLine[0];
            string currentAuthor = inputLine[1];
            string currentPublisher = inputLine[2];
            DateTime currentReleaseDate = DateTime.ParseExact(inputLine[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            string currentISBN = inputLine[4];
            double currentPrice = double.Parse(inputLine[5]);

            Book currentBook = new Book()
            {
                Title = currentTitle,
                Author = currentAuthor,
                Publisher = currentPublisher,
                ReleaseDate = currentReleaseDate,
                ISBN = currentISBN,
                Price = currentPrice
            };

            listOfBooks.Add(currentBook);
        }
        DateTime dateToSearch = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
        var result = listOfBooks.Where(b => b.ReleaseDate > dateToSearch).ToList();
        foreach (Book book in result.OrderBy(b => b.ReleaseDate).ThenBy(b => b.Title))
        {
            Console.WriteLine($"{book.Title} -> {book.ReleaseDate:dd.MM.yyyy}");
        }
    }
}

class Book
{
    public string Title { get; set; }

    public string Author { get; set; }

    public string Publisher { get; set; }

    public DateTime ReleaseDate { get; set; }

    public string ISBN { get; set; }

    public double Price { get; set; }
}