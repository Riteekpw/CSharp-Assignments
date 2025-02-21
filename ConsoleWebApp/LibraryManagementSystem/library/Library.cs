using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.book;
using LibraryManagementSystem.member;

namespace LibraryManagementSystem.library
{
    class Library
    {
        private List<Book> books;
        private List<Member> members;

        public List<Book> Books => books;
        public List<Member> Members => members;

        public Library()
        {
            this.books = new ArrayList<>();
            this.members = new ArrayList<>();
        }

        public void AddBook(Book book)
        {
            books.add(book);
        }


        public void RegisterMember(Member member)
        {
            members.add(member);
        }

        public void ListBooks()
        {
            for (Book book : books)
            {
                book.displayDetails();
            }
        }
    }
}
