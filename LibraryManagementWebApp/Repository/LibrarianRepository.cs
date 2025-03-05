using LibraryManagementWebApp.Data;
using LibraryManagementWebApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementWebApp.Repository
{
    public class LibrarianRepository
    {
        private LibraryContext _context;

        public LibrarianRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task<Librarian> getLibrarian()
        {
            return _context.Librarian.Where(id => id.Id == 1).FirstOrDefault();
        }
    }
}
