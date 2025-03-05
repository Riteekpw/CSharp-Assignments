using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrayManagementSystem1.model;

namespace LibraryManagementSystem1.repository
{
    public interface IBorrowRepository
    {
        Task<MemberBook> FindByMemberAndBookAsync(int memberId, int bookId);
        Task AddAsync(MemberBook memberBook);
        Task SaveChangesAsync();
    }
}
