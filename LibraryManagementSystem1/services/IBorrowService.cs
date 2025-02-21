using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem1.services
{
    public interface IBorrowService : IService
    {
        void BorrowBook(int memberId, int bookId);
        void ReturnBook(int memberId, int bookId);
    }
}
