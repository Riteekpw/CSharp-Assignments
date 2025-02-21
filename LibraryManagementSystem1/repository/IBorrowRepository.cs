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
        MemberBook FindByMemberAndBook(int memberId, int bookId);
        void Add(MemberBook memberBook);
        void Remove(MemberBook memberBook);
        void SaveChanges();
    }
}
