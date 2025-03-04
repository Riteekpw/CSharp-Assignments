using LibraryManagementWebApp.Entity;
using LibraryManagementWebApp.Model;
using LibraryManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementWebApp.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [Route("getall")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookModel>>> GetBooks()
        {
            var books = await _bookService.GetBooksAsync();

            
            var bookModels = books.Select(b => new BookModel
            {
                Title = b.Title,
                Author = b.Author,
                ISBN = b.ISBN,
                IsAvailable = b.IsAvailable
            }).ToList();

            return Ok(bookModels);
        }

        [Route("get/{id}")]
        [HttpGet]
        public async Task<ActionResult<BookModel>> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);


            var bookModels =  new BookModel
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                IsAvailable = book.IsAvailable
            };

            return Ok(bookModels);
        }


        [HttpPost("add")]
        public async Task<ActionResult<BookModel>> AddBook(BookModel bookModel)
        {

            var book = new Book
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                ISBN = bookModel.ISBN
            };

            await _bookService.AddBookAsync(book);
            return Ok();
        }

    }
}
