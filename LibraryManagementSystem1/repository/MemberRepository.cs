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
    public class MemberRepository : IMemberRepository
    {
        private  LibraryDbContext context;

        public MemberRepository(LibraryDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Member member)
        {
            await context.Members.AddAsync(member);
        }

        public async Task<Member> FindByIdAsync(int memberId)
        {
            return await context.Members.Where(mb => mb.MemberId==memberId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            return await context.Members.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
