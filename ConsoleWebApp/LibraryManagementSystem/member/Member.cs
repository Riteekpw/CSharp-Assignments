using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.book;
using LibraryManagementSystem.library;

namespace LibraryManagementSystem.member
{
    class Member : Person
    {
        private int memberId;
        private List<Book> borrowedBooks;

        public int MemberId
        {
            get { return memberId; }
            set { memberId = value; }
        }

        public List<Book> BorrowedBooks
        {
            get { return borrowedBooks; }
            set { borrowedBooks = value; }
        }

        public Member(string name,int memberId) : base(name)
        {
            this.memberId = memberId;
            this.borrowedBooks = new List<Book>();
        }


        public override void BorrowBook(Book book)
        {
            if (book.IsAvailable())
            {
                book.BorrowBook();
                borrowedBooks.Add(book);
            }
            else
            {
                Console.WriteLine($"{book.GetTitle()} is currently unavailable.");
            }
        }

        public override void ReturnBook(Book book)
        {
            if (borrowedBooks.Contains(book))
            {
                book.ReturnBook();
                borrowedBooks.Remove(book);
            }
            else
            {
                Console.WriteLine($"{book.GetTitle()} was not borrowed by {name}.");
            }
        }
    }
}
