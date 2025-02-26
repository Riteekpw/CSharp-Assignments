using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem1.services
{
    public interface IBookService 
    {
        Task AddBookAsync(string title, string author, string isbn);
        Task AddEBookAsync(string title, string author, string isbn, int fileSize, string fileFormat);
        Task ListBooksAsync();
    }
}
