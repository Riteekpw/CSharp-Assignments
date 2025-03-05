using System.Net;
using LibraryManagementWebApp.Entity;
using LibraryManagementWebApp.Repository;

namespace LibraryManagementWebApp.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            return await _bookRepository.FindByIdAsync(bookId);
        }

        public async Task AddBookAsync(Book book)
        {
            await _bookRepository.AddAsync(book);
        }

        public async Task AddEBookAsync(EBook ebook)
        {
            await _bookRepository.AddEBookAsync(ebook);
        }

        public async Task DeleteBook(int id)
        {
            var book = await _bookRepository.FindByIdAsync(id);
            await _bookRepository.DeleteBookAsync(book);
        }

        public async Task UpdateBookAsync(Book book)
        {
            _bookRepository.Update(book);
        }
    }
}
