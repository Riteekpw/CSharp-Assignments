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
        private  LibraryDbContext context;

        public BorrowService()
        {
            context = new LibraryDbContext();
            bookRepository = new BookRepository(context);
            memberRepository = new MemberRepository(context);
            borrowRepository = new BorrowRepository(context);
        }

        public void BorrowBook(int memberId, int bookId)
        {
            var member = memberRepository.FindById(memberId);
            var book = bookRepository.FindById(bookId);

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

            borrowRepository.Add(memberBook);
            borrowRepository.SaveChanges();

            Console.WriteLine("Book borrowed successfully.");
        }

        public void ReturnBook(int memberId, int bookId)
        {
            var member = memberRepository.FindById(memberId);
            var book = bookRepository.FindById(bookId);

            if (member == null || book == null)
            {
                Console.WriteLine("Invalid member or book ID.");
                return;
            }

            var memberBook = borrowRepository.FindByMemberAndBook(memberId, bookId);
            if (memberBook == null)
            {
                Console.WriteLine("This book was not borrowed by the member.");
                return;
            }

            book.IsAvailable = true;
            bookRepository.Update(book);
            memberBook.BookStatus = "returned";
            memberBook.ReturnedOn = DateTime.Now;
            borrowRepository.SaveChanges();

            Console.WriteLine("Book returned successfully.");
        }
    }
}
