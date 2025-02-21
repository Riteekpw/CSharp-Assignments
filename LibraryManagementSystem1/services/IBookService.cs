using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem1.services
{
    public interface IBookService : IService
    {
        void AddBook(string title, string author, string isbn);
        void AddEBook(string title, string author, string isbn, int fileSize, string fileFormat);
        void ListBooks();
    }
}
