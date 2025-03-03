using LibraryManagementWebApp.Data;
using LibraryManagementWebApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementWebApp.Repository
{
    public class BookRepository
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
    }
}
