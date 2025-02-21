using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LibraryManagementSystem.book;
using LibraryManagementSystem.library;
using LibrayManagementSystem.member;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem.member
{
    class Member : Person
    {
        private int memberId;
        MapMemberToBook mapMemberToBook;
    

        public int MemberId
        {
            get { return memberId; }
            set { memberId = value; }
        }

    

        public Member(string name, int memberId) : base(name)
        {
            this.memberId = memberId;
            this.mapMemberToBook = new MapMemberToBook();
        }

        public override void BorrowBook(Book book)
        {
            if (book.Available)
            {
                book.Available = false;
                mapMemberToBook.MapMember(memberId, book.BookId);
                Console.WriteLine($"Enjoy Reading :{book.Title}");
            }
            else
            {
                Console.WriteLine("Book is Not Available Right Now");
            }
        }

        public override void ReturnBook(Book book)
        {
            book.Available = true;
            mapMemberToBook.RemoveMapping(memberId, book.BookId);
        }


        
    }
}
