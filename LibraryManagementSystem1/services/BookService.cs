using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem1.data;
using LibraryManagementSystem1.repository;
using LibrayManagementSystem1.model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LibraryManagementSystem1.services
{
    
    public class BookService : IBookService
    {
       // private readonly Microsoft.Extensions.Logging.ILogger _logger;
        private readonly ILogger<BookService> _logger;
        private  IBookRepository bookRepository;
        private  LibraryDbContext _context;

        public BookService(ILogger<BookService> logger,IBookRepository bookRepository, LibraryDbContext context)
        {
            _logger = logger;
            _context = context;
            this.bookRepository = bookRepository;
        }

        public BookService(IBookRepository bookRepo)
        {
            bookRepository = bookRepo;
        }

        public async Task AddBookAsync(string title, string author, string isbn)
        {
            _logger.LogInformation("invalid");
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
            _logger.LogInformation($"Sucess {title} added");
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
