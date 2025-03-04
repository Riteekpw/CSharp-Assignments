using LibraryManagementWebApp.Entity;

namespace LibraryManagementWebApp.Repository
{
    public interface IBorrowRepository
    {
        Task<MemberMapToBook> FindByMemberAndBookAsync(int memberId, int bookId);
        Task AddAsync(MemberMapToBook memberBook);
        Task SaveChangesAsync();
    }
}
