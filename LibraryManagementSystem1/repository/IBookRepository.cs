using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrayManagementSystem1.model;

namespace LibraryManagementSystem1.repository
{
     public interface IBookRepository
    {
        Task AddAsync(Book book);
        Task<Book> FindByIdAsync(int bookId);
        Task<IEnumerable<Book>> GetAllAsync();
        void Update(Book book);
        Task SaveChangesAsync();
    }
}
