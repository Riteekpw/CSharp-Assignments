using LibraryManagementWebApp.Entity;
using LibraryManagementWebApp.Model;
using LibraryManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog.Sinks.File;

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


        [Route("book/getall")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookModel>>> GetBooks()
        {
            var books = await _bookService.GetBooksAsync();

            if (books == null)
            {
                return NotFound();
            }

            var bookModels = books.Select(b => new BookModel
            {
                Title = b.Title,
                Author = b.Author,
                ISBN = b.ISBN,
                IsAvailable = b.IsAvailable
            }).ToList();

            return Ok(bookModels);
        }

        [Route("book/get/{id}")]
        [HttpGet]
        public async Task<ActionResult<BookModel>> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if(book == null)
            {
                return NotFound();
            }

            var bookModels =  new BookModel
            {   BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                IsAvailable = book.IsAvailable
            };

            return Ok(bookModels);
        }


        [HttpPost("book/add")]
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

        [HttpPost("book/addEbook")]
        public async Task<ActionResult<BookModel>> AddEBook(EBookModel bookModel)
        {

            var book = new Book
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                ISBN = bookModel.ISBN
            };

            await _bookService.AddBookAsync(book);

            var ebook = new EBook
            {
                FileSize = bookModel.FileSize,
                FileFormat = bookModel.FileFormat,
                BookId = book.BookId
            };

            await _bookService.AddEBookAsync(ebook);
            return Ok();
        }

        [HttpPut("book/update")]
        public async Task<ActionResult> UpdateBook(BookModel bookModel)
        {
            var book = new Book
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                ISBN = bookModel.ISBN
            };
            await _bookService.UpdateBookAsync(book);
            return Ok();
        }

        [HttpDelete("book/delete/{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBook(id);
            return Ok();
        }

    }
}
