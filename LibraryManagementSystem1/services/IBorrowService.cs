using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem1.services
{
    public interface IBorrowService
    {
        Task BorrowBookAsync(int memberId, int bookId);
        Task ReturnBookAsync(int memberId, int bookId);
    }
}
