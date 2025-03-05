using LibraryManagementWebApp.Entity;

namespace LibraryManagementWebApp.Repository
{
    public interface IBookRepository
    {
        Task AddAsync(Book book);
        Task<List<Book>> GetAllAsync();
        Task<Book> FindByIdAsync(int bookId);
        void Update(Book book);
        Task SaveChangesAsync();
        Task AddEBookAsync(EBook ebook);
        Task DeleteBookAsync(Book book);
    }
}
