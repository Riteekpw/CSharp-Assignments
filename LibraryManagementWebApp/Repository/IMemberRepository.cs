using LibraryManagementWebApp.Entity;
using System.Threading.Tasks;

namespace LibraryManagementWebApp.Repository
{
    public interface IMemberRepository
    {
        Task AddAsync(Member member);
        Task<Member> FindByIdAsync(int memberId);
        Task<List<Member>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
