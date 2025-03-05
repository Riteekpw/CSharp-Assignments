
using LibraryManagementWebApp.Entity;
using LibraryManagementWebApp.Repository;

namespace LibraryManagementWebApp.Services
{
    public class LibrarianService
    {
        private LibrarianRepository librarianRepository;

        public LibrarianService(LibrarianRepository librarianRepository)
        {
            this.librarianRepository = librarianRepository;
        }
        public async Task<Librarian> getLibrarianAsync()
        {
            return await librarianRepository.getLibrarian();
        }
    }
}
