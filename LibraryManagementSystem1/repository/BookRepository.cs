using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem1.data;
using LibrayManagementSystem1.model;

namespace LibraryManagementSystem1.repository
{
    public class BookRepository : IBookRepository
    {
        private LibraryDbContext context;

        public BookRepository(LibraryDbContext context)
        {
            this.context = context;
        }

        public void Add(Book book)
        {
            context.Books.Add(book);
        }

        public Book FindById(int bookId)
        {
            return context.Books.Find(bookId);
        }

        public IEnumerable<Book> GetAll()
        {
            return context.Books.ToList();
        }

        public void Update(Book book)
        {
            context.Books.Update(book);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
