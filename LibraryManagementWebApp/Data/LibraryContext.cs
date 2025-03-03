

using LibraryManagementWebApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementWebApp.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books {  get; set; }
        public DbSet<EBook> EBooks {  get; set; }
        public DbSet<Member> Members { get; set; } 
        public DbSet<MemberMapToBook> MembersMapToBook { get; set; }
        public DbSet<Librarian> Librarian { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

    }
}
