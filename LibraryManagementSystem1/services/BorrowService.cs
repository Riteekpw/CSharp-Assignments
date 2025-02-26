using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem1.data;
using LibraryManagementSystem1.repository;
using LibrayManagementSystem1.model;

namespace LibraryManagementSystem1.services
{
    public class BorrowService : IBorrowService
    {
        private  IBookRepository bookRepository;
        private  IMemberRepository memberRepository;
        private  IBorrowRepository borrowRepository;
        private  LibraryDbContext _context;
        private IBookRepository object1;
        private IMemberRepository object2;
        private IBorrowRepository object3;

        public BorrowService()
        {
            _context = new LibraryDbContext();
            bookRepository = new BookRepository(_context);
            memberRepository = new MemberRepository(_context);
            borrowRepository = new BorrowRepository(_context);
        }

        public BorrowService(IBookRepository object1, IMemberRepository object2, IBorrowRepository object3)
        {
            this.object1 = object1;
            this.object2 = object2;
            this.object3 = object3;
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

            var memberBook = new MemberBook
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
