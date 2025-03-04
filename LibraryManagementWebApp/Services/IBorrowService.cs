namespace LibraryManagementWebApp.Services
{
    public interface IBorrowService
    {
        Task BorrowBookAsync(int memberId, int bookId);
        Task ReturnBookAsync(int memberId, int bookId);
    }
}
