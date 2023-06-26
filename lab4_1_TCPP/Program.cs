using System;
using System.Collections.Generic;
using ConsoleTables;

namespace lab4_1_TCPP
{
    class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
    }

    class Library
    {
        public List<Book> Books { get; set; }

        public Library()
        {
            Books = new List<Book>();
            Books.Add(new Book() { Author = "J.K. Rowling", Title = "Harry Potter and the Sorcerer's Stone", Publisher = "Bloomsbury Publishing", Year = 1997 });
            Books.Add(new Book() { Author = "J.R.R. Tolkien", Title = "The Lord of the Rings", Publisher = "Allen & Unwin", Year = 1954 });
            Books.Add(new Book() { Author = "Stephen King", Title = "The Shining", Publisher = "Doubleday", Year = 1977 });
            Books.Add(new Book() { Author = "Toni Morrison", Title = "Beloved", Publisher = "Alfred A. Knopf", Year = 1987 });
            Books.Add(new Book() { Author = "Gabriel García Márquez", Title = "One Hundred Years of Solitude", Publisher = "La Oveja Negra", Year = 1967 });
            Books.Add(new Book() { Author = "Leo Tolstoy", Title = "War and Peace", Publisher = "A.T. Alekseev", Year = 1869 });
            Books.Add(new Book() { Author = "Fyodor Dostoevsky", Title = "Crime and Punishment", Publisher = "Dostoevsky's Journal", Year = 1866 });
            Books.Add(new Book() { Author = "Charles Dickens", Title = "A Tale of Two Cities", Publisher = "Chapman & Hall", Year = 1859 });
            Books.Add(new Book() { Author = "Jane Austen", Title = "Pride and Prejudice", Publisher = "John Murray", Year = 1813 });
            Books.Add(new Book() { Author = "George Orwell", Title = "Animal Farm: A Fairy Story", Publisher = "Secker & Warburg", Year = 1945 });
        }

        public void SortByAuthor()
        {
            Books.Sort((x, y) => x.Author.CompareTo(y.Author));
        }

        public void CountBooksByPublisher()
        {
            Dictionary<string, int> publishers = new Dictionary<string, int>();
            foreach (Book book in Books)
            {
                if (!publishers.ContainsKey(book.Publisher))
                {
                    publishers.Add(book.Publisher, 1);
                }
                else
                {
                    publishers[book.Publisher]++;
                }
            }

            var table = new ConsoleTable("Видавництво", "Кількість книг");
            foreach (var publisher in publishers)
            {
                table.AddRow(publisher.Key, publisher.Value);
            }

            Console.WriteLine(table.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Sort the books by author
            library.SortByAuthor();

            // Count the number of books from each publisher
            library.CountBooksByPublisher();

            // Display the books in a table
            var table = new ConsoleTable("Автор", "Назва книги", "Видавництво", "Рік");
            foreach (Book book in library.Books)
            {
                table.AddRow(book.Author, book.Title, book.Publisher, book.Year);
            }

            Console.WriteLine(table.ToString());
        }
    }
}
