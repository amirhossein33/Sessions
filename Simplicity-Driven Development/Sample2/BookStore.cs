namespace Simplicity_Driven_Development.Sample2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace BookStore
    {
        //  مدل کتاب 
        public class Book
        {
            public string? Title { get; set; }
            public string? Author { get; set; }
            public double Price { get; set; }
            public string? Genre { get; set; }
        }

        // مدل کاربر 
        public class User
        {
            public string? Name { get; set; }
            public string? Email { get; set; }

        }

        //  اصل DRY: محاسبه قیمت در یک مکان 
        public static class OrderCalculator
        {
            public static double CalculateTotalPrice(List<Book> books)
            {
                return books.Sum(book => book.Price);
            }
        }

        //  مدیریت سفارش 
        public class Order
        {
            public User? User { get; set; }
            public List<Book> Books { get; set; } = new List<Book>();

            public void AddBook(Book book)
            {
                Books.Add(book);
            }

            public double GetTotalPrice()
            {
                return OrderCalculator.CalculateTotalPrice(Books);
            }
        }

        // اصل KISS: فیلتر کردن کتاب‌ها 
        public static class BookFilter
        {
            public static List<Book> FilterByGenre(List<Book> books, string genre)
            {
                return books.Where(book => book.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        //  اجرای برنامه 
        public class Program
        {
            public static void Main(string[] args)
            {
                //  لیست کتاب‌ها 
                var books = new List<Book>
            {
                new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Price = 10.99, Genre = "Fiction" },
                new Book { Title = "1984", Author = "George Orwell", Price = 8.99, Genre = "Dystopian" },
                new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Price = 12.99, Genre = "Fiction" },
                new Book { Title = "Sapiens", Author = "Yuval Noah Harari", Price = 14.99, Genre = "History" }
            };

                //  کاربر 
                var user = new User { Name = "Alice", Email = "alice@example.com" };

                //  سفارش 
                var order = new Order { User = user };
                order.AddBook(books[0]); // افزودن کتاب به سفارش
                order.AddBook(books[2]);

                //  اصل KISS: فیلتر کردن کتاب‌ها 
                Console.WriteLine("\nBooks in the 'Fiction' genre:");
                var fictionBooks = BookFilter.FilterByGenre(books, "Fiction");
                foreach (var book in fictionBooks)
                {
                    Console.WriteLine($"- {book.Title} by {book.Author}");
                }

                //  اصل DRY: محاسبه قیمت کل 
                Console.WriteLine($"\nTotal price for {user.Name}'s order:");
                Console.WriteLine($"$ {order.GetTotalPrice()}");
            }
        }
    }
}