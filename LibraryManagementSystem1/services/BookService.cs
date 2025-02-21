using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem1.data;
using LibraryManagementSystem1.repository;
using LibrayManagementSystem1.model;

namespace LibraryManagementSystem1.services
{
    public class BookService : IBookService
    {
        private  IBookRepository bookRepository;
        private  LibraryDbContext context;

        public BookService()
        {
            context = new LibraryDbContext();
            bookRepository = new BookRepository(context);
        }

        public void AddBook(string title, string author, string isbn)
        {
            var book = new Book
            {
                Title = title,
                Author = author,
                ISBN = isbn,
                IsEbook = "false",
                IsAvailable = true,
                IsDeleted = false
            };

            bookRepository.Add(book);
            bookRepository.SaveChanges();
            Console.WriteLine("Physical book added successfully.");
        }

        public void AddEBook(string title, string author, string isbn, int fileSize, string fileFormat)
        {
            var book = new Book
            {
                Title = title,
                Author = author,
                ISBN = isbn,
                IsEbook = "true",
                IsAvailable = true,
                IsDeleted = false
            };

            bookRepository.Add(book);
            bookRepository.SaveChanges();

            var ebook = new Ebook
            {
                FileSize = fileSize,
                FileFormat = fileFormat,
                BookId = book.BookId
            };

            context.Ebooks.Add(ebook);
            context.SaveChanges();
            Console.WriteLine("EBook added successfully.");
        }

        public void ListBooks()
        {
            var books = bookRepository.GetAll();
            Console.WriteLine("\nList of Books:");
            foreach (var book in books)
            {
                book.DisplayDetails();
                Console.WriteLine("------------------------");
            }
        }
    }
}
