using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrayManagementSystem1.model;

namespace LibraryManagementSystem1.repository
{
    public interface IMemberRepository
    {
        Task AddAsync(Member member);
        Task<Member> FindByIdAsync(int memberId);
        Task<IEnumerable<Member>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
