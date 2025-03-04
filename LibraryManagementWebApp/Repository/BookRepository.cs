using LibraryManagementWebApp.Data;
using LibraryManagementWebApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementWebApp.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> FindByIdAsync(int bookId)
        {
            return await _context.Books.Where(BK => BK.BookId == bookId).FirstOrDefaultAsync();
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

      
    }
}
