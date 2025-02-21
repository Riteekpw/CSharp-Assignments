using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem1.data;
using LibrayManagementSystem1.model;

namespace LibraryManagementSystem1.repository
{
    public class BorrowRepository : IBorrowRepository
    {
        private LibraryDbContext context;

        public BorrowRepository(LibraryDbContext context)
        {
            this.context = context;
        }

        public MemberBook FindByMemberAndBook(int memberId, int bookId)
        {
            return context.MemberBooks.FirstOrDefault(mb => mb.MemberId == memberId && mb.BookId == bookId);
        }

        public void Add(MemberBook memberBook)
        {
            context.MemberBooks.Add(memberBook);
        }

        public void Remove(MemberBook memberBook)
        {
            context.MemberBooks.Remove(memberBook);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
