using LibraryManagementWebApp.Entity;

namespace LibraryManagementWebApp.Services
{
    public interface IMemberService
    {
        Task RegisterMemberAsync(string name, int age);
        Task ListMembersAsync();
        Task<List<Member>> GetAllMembersAsync();
        Task<Member> GetMemberByIdAsync(int id);
    }
}
