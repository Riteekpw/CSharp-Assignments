using LibraryManagementWebApp.Data;
using LibraryManagementWebApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementWebApp.Repository
{
    public class BorrowRepository : IBorrowRepository
    {
        private LibraryContext context;

        public BorrowRepository(LibraryContext context)
        {
            this.context = context;
        }

        public async Task<MemberMapToBook> FindByMemberAndBookAsync(int memberId, int bookId)
        {
            return await context.MemberMapToBook.Where(mb => mb.MemberId == memberId && mb.BookId == bookId).FirstOrDefaultAsync();
        }

        public async Task AddAsync(MemberMapToBook memberBook)
        {
            await context.MemberMapToBook.AddAsync(memberBook);
        }



        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}

