using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev_II
{
    public class Book
    {
        // Instances
        public string Title { get; set; }
        public int Pages { get; set; }
        public int PublicationYear { get; set; }

        // Constructor
        public Book(string title, int pages, int publicationYear)
        {
            Title = title;
            Pages = pages;
            PublicationYear = publicationYear;
        }

        // Override Method
        public override string ToString()
        {
            return $"{Title}, {Pages} pages, {PublicationYear}";
        }

        // Save books to file 
        public static void SaveBooksToFile(List<Book> books, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Book book in books)
                {
                    writer.WriteLine($"{book.Title},{book.Pages},{book.PublicationYear}");
                }
            }
        }

        // Load books to file 
        public static List<Book> LoadBooksFromFile(string filePath)
        {
            List<Book> books = new List<Book>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        string title = parts[0];
                        int pages = int.Parse(parts[1]);
                        int publicationYear = int.Parse(parts[2]);
                        books.Add(new Book(title, pages, publicationYear));
                    }
                }
            }
            return books;
        }
    }
}
