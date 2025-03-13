using LibraryManagementWebApp.Data;
using LibraryManagementWebApp.Entity;
using LibraryManagementWebApp.Repository;
using Serilog;

namespace LibraryManagementWebApp.Services
{
    public class BorrowService : IBorrowService
    {
        private IBookRepository bookRepository;
        private IMemberRepository memberRepository;
        private IBorrowRepository borrowRepository;

        public BorrowService(IBookRepository bookRepository, IMemberRepository memberRepository, IBorrowRepository borrowRepository, LibraryContext context)
        {
            this.bookRepository = bookRepository;
            this.memberRepository = memberRepository;
            this.borrowRepository = borrowRepository;
        }

        public async Task BorrowBookAsync(int memberId, int bookId)
        {
            var member = await memberRepository.FindByIdAsync(memberId);
            var book = await bookRepository.FindByIdAsync(bookId);

            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }
            if (!book.IsAvailable)
            {
                Console.WriteLine("Book is not available.");
                return;
            }

            book.IsAvailable = false;
            bookRepository.Update(book);


            var memberBook = new MemberMapToBook
            {
                MemberId = memberId,
                BookId = bookId,
                BorrowedOn = DateTime.Now
            };

            await borrowRepository.AddAsync(memberBook);
            await borrowRepository.SaveChangesAsync();

            Console.WriteLine("Book borrowed successfully.");
        }

        public async Task ReturnBookAsync(int memberId, int bookId)
        {
            var member = await memberRepository.FindByIdAsync(memberId);
            var book = await bookRepository.FindByIdAsync(bookId);

            if (member == null || book == null)
            {
                Console.WriteLine("Invalid member or book ID.");
                return;
            }

            var memberBook = await borrowRepository.FindByMemberAndBookAsync(memberId, bookId);
            if (memberBook == null)
            {
                Console.WriteLine("This book was not borrowed by the member.");
                return;
            }

            book.IsAvailable = true;
            bookRepository.Update(book);
            memberBook.BookStatus = "returned";
            memberBook.ReturnedOn = DateTime.Now;
            await borrowRepository.SaveChangesAsync();

            Console.WriteLine("Book returned successfully.");
        }
    }
}
