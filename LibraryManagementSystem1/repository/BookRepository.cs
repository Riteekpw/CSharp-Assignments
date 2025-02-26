using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem1.data;
using LibrayManagementSystem1.model;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem1.repository
{
    public class BookRepository : IBookRepository
    {
        private LibraryDbContext context;

        public BookRepository(LibraryDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Book book)
        {
            await context.Books.AddAsync(book);
        }

        public async Task<Book> FindByIdAsync(int bookId)
        {
            return   await context.Books.Where(BK => BK.BookId == bookId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await context.Books.ToListAsync();
        }

        public void Update(Book book)
        {
            context.Books.Update(book);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
