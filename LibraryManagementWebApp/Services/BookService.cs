using LibraryManagementWebApp.Entity;
using LibraryManagementWebApp.Repository;

namespace LibraryManagementWebApp.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task AddBookAsync(Book book)
        {
            await _bookRepository.AddAsync(book);
        }
    }
}
