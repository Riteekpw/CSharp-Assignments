using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem1.data;
using LibrayManagementSystem1.model;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem1.repository
{
    public class BorrowRepository : IBorrowRepository
    {
        private LibraryDbContext context;

        public BorrowRepository(LibraryDbContext context)
        {
            this.context = context;
        }

        public async Task<MemberBook> FindByMemberAndBookAsync(int memberId, int bookId)
        {
            return await context.MemberBooks.Where(mb => mb.MemberId == memberId && mb.BookId == bookId).FirstOrDefaultAsync();
        }

        public async Task AddAsync(MemberBook memberBook)
        {
            await context.MemberBooks.AddAsync(memberBook);
        }



        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
