using LibraryManagementWebApp.Entity;

namespace LibraryManagementWebApp.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksAsync();
        Task  AddBookAsync(Book book);
        Task<Book> GetBookByIdAsync(int bookId);
        Task AddEBookAsync(EBook ebook);
        Task DeleteBook(int id);
        Task UpdateBookAsync(Book book);
    }
}
