using LibraryManagementWebApp.Data;
using LibraryManagementWebApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementWebApp.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private LibraryContext context;

        public MemberRepository(LibraryContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Member member)
        {
            await context.Members.AddAsync(member);
        }

        public async Task<Member> FindByIdAsync(int memberId)
        {
            return await context.Members.Where(mb => mb.MemberId == memberId).FirstOrDefaultAsync();
        }

        public async Task<List<Member>> GetAllAsync()
        {
            return await context.Members.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
