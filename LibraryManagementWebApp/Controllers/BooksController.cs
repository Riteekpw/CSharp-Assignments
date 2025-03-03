using LibraryManagementWebApp.Entity;
using LibraryManagementWebApp.Model;
using LibraryManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/books/get
        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<BookModel>>> GetBooks()
        {
            var books = await _bookService.GetBooksAsync();

            // Map Book entities to BookModel for the response
            var bookModels = books.Select(b => new BookModel
            {
                Title = b.Title,
                Author = b.Author,
                ISBN = b.ISBN,
                IsAvailable = b.IsAvailable
            }).ToList();

            return Ok(bookModels);
        }

        // POST: api/books/add
        [HttpPost("add")]
        public async Task<ActionResult<BookModel>> AddBook(BookModel bookModel)
        {
            if (bookModel.IsEBook == null)
            {
                bookModel.IsEBook = "false"; // Ensure IsEbook is set
            }

            var book = new Book
            {
                Title = bookModel.Title,
                IsEBook = bookModel.IsEBook
            };

            await _bookService.AddBookAsync(book);
            return Ok();
        }
    }
}
