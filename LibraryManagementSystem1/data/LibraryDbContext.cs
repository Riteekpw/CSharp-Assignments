
using LibraryManagementSystem1.Enitity;
using LibrayManagementSystem1.model;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem1.data
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Ebook> Ebooks { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberBook> MemberBooks { get; set; }
        public DbSet<LibrarianInfo> Librarians { get; set; }


        public string ConnectionString { get; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        {

            ConnectionString = @"Server=P2021-PC00312\SQLEXPRESS;Database=Library;Trusted_Connection=True;TrustServerCertificate=True";
        }
        public LibraryDbContext()
        {

            ConnectionString = @"Server=P2021-PC00312\SQLEXPRESS;Database=Library;Trusted_Connection=True;TrustServerCertificate=True";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(ConnectionString);
    }
}
