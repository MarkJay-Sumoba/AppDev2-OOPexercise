using System;
using System.Collections.Generic;
using System.IO;

namespace AppDev_II
{
    public class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            // Log a Welcome Message
            log.Info("Starting OOP exercise \n");
            log.Info("Starting PaymentCard Class");
            // #1
            Console.WriteLine("I.) Payment Card");
            // Log Info Create PaymentCard Object
            log.Info("Creating PaymentCard object (card)");
            PaymentCard card = new PaymentCard(50);
            log.Info("PaymentCard object created: " + card + "\n");
            Console.WriteLine("Intial Balance");
            // Log Info Initial Card Balance
            Console.WriteLine(card);
            Console.WriteLine("\n");

            // #2
            Console.WriteLine("II.) Using Card");
            // Log Info Create PaymentCard Object
            log.Info("Creating PaymentCard object (card2)");
            PaymentCard card2 = new PaymentCard(50);
            log.Info("PaymentCard object (card2) created: " + card2);
            // Log Info Card Balance after Eating Lunch 
            Console.WriteLine("Use Card to Eat Lunch");
            card2.EatLunch();
            log.Info("Card2 balance after eating lunch: " + card2);
            Console.WriteLine(card2);
            // Log Info Card Balance after Drinking Coffee 
            Console.WriteLine("Use Card to Drink Coffee");
            card2.DrinkCoffee();
            log.Info("Card2 balance after drinking coffee: " + card2 + "\n");
            Console.WriteLine(card2);
            Console.WriteLine("\n");

            // #3
            Console.WriteLine("III.) Checking Balance");
            // Log Info Create PaymentCard Object 
            log.Info("Creating PaymentCard object (card3)");
            PaymentCard card3 = new PaymentCard(10);
            log.Info("PaymentCard object (card3) created: " + card3);
            Console.WriteLine("Intial Balance");
            // Log Info Initial Card Balance 
            Console.WriteLine(card3);
            Console.WriteLine("Use Card to Eat Lunch");
            card3.EatLunch();
            // Log Info Card Balance after Eating Lunch 
            log.Info("Card3 balance after eating lunch: " + card2);
            Console.WriteLine(card3);
            Console.WriteLine("Use Card to Drink Coffee");
            card3.DrinkCoffee();
            // Log Info Card Balance after Drinking Coffee 
            log.Info("Card2 balance after drinking coffee: " + card2 + "\n");
            Console.WriteLine(card3);
            Console.WriteLine("\n");

            // #4
            Console.WriteLine("IV.) Charging Card");
            // Log Info Create PaymentCard Object
            log.Info("Creating PaymentCard object (card4)");
            PaymentCard card4 = new PaymentCard(100);
            log.Info("PaymentCard object (card4) created: " + card4);
            Console.WriteLine("Intial Balance");
            // Log Info Initial Card Balance 
            Console.WriteLine(card4);
            // Log Info after adding 49.99 euros
            Console.WriteLine("Add 49.99");
            card4.AddMoney(49.99);
            log.Info("Balance after adding 49.99: " + card4);
            Console.WriteLine(card4);
            // Log Info after adding 10000.0 euros
            Console.WriteLine("Add 10000.0");
            card4.AddMoney(10000.0);
            log.Info("Balance after adding 10000.0: " + card4);
            Console.WriteLine(card4);
            // Log Info after adding -10.0 euros
            Console.WriteLine("Add -10.0");
            card4.AddMoney(-10);
            log.Info("Balance after adding -10.0: " + card4 + "\n");
            Console.WriteLine(card4);
            Console.WriteLine("\n");

            // #5
            log.Info("Starting Book Class");
            Console.WriteLine("V.) Book Class");
            // Initialize a new list to store Book objects
            List<Book> books = new List<Book>();
            // Define the file path for the CSV file
            string filePath = @"..\..books.csv";
            // Verify if file exists before loading books
            if (File.Exists(filePath))
            {
                // Load Book from File Path and Log Information
                // log.Info("Loading books from file: " + filePath);
                books = Book.LoadBooksFromFile(filePath);
                log.Info("Books loaded from file: " + filePath);
            }
            // Prompt user for Book information
            do
            {
                // Input Title
                Console.Write("Name: ");
                string title = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(title)) break;
                // Input Pages
                Console.Write("Pages: ");
                int pages = int.Parse(Console.ReadLine());
                // Input Publication Year
                Console.Write("Publication Year: ");
                int publicationYear = int.Parse(Console.ReadLine());
                // Add new Book
                books.Add(new Book(title, pages, publicationYear));
                // Log added Book
                log.Info("Book added: " + title + ", Pages: " + pages + ", Publication Year: " + publicationYear);
                // Prompt user to continue adding book
                Console.Write("Do you want to add another book? (yes (y)/no (Enter any key): ");
                string answer = Console.ReadLine();
                if (answer.ToLower() != "y") break;
            }
            while (true);
            // Save Books to filepath and Log Information
            log.Info("Saving books to file: " + filePath);
            Book.SaveBooksToFile(books, filePath);
            log.Info("Books saved to file: " + filePath + "\n");
            // Print to CSV
            Console.WriteLine("What information will be printed? (Select number)");
            Console.WriteLine("1. All (Title, Pages, Publication Year");
            Console.WriteLine("2. Title of the Books");
            string input = Console.ReadLine();
            if (input == "1")
            {
                foreach (Book book in books) 
                {
                    log.Info(book);
                    Console.WriteLine(book + "\n");
                }
            }
            else if (input == "2")
            {
                foreach(Book book in books)
                {
                    log.Info(book.Title);
                    Console.WriteLine(book.Title + "\n");

                }
            }
            Console.ReadLine();
            // Log an exit message
            log.Info("Exiting OOP Exercise");
        }
    }
}
