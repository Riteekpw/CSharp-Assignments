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
        private  LibraryDbContext _context;

        public BookService()
        {
            _context = new LibraryDbContext();
            bookRepository = new BookRepository(_context);
        }

        public BookService(IBookRepository bookRepo)
        {
            bookRepository = bookRepo;
        }

        public async Task AddBookAsync(string title, string author, string isbn)
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

            await bookRepository.AddAsync(book);
            await bookRepository.SaveChangesAsync();
            Console.WriteLine("Physical book added successfully.");
        }

        public async Task AddEBookAsync(string title, string author, string isbn, int fileSize, string fileFormat)
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

            await bookRepository.AddAsync(book);
            await bookRepository.SaveChangesAsync();

            var ebook = new Ebook
            {
                FileSize = fileSize,
                FileFormat = fileFormat,
                BookId = book.BookId
            };

            _context.Ebooks.Add(ebook);
            _context.SaveChanges();
            Console.WriteLine("EBook added successfully.");
        }

        public async Task ListBooksAsync()
        {
            var books = await bookRepository.GetAllAsync();
            Console.WriteLine("\nList of Books:");
            foreach (var book in books)
            {
                book.DisplayDetails();
                Console.WriteLine("------------------------");
            }
        }
    }
}
