using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrayManagementSystem1.model;

namespace LibraryManagementSystem1.repository
{
     interface IBookRepository
    {
        void Add(Book book);
        Book FindById(int bookId);
        IEnumerable<Book> GetAll();
        void Update(Book book);
        void SaveChanges();
    }
}
