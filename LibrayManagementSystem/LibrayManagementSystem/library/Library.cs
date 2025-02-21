using System;
using System.Collections;
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

    public List<Book> Books
    {
         set { books = value; }
         get { return books; }
    }

    public List<Member> Members
    {
         set { Members = value; }
         get { return Members; }
    }

        public Library()
    {
        books = new List<Book>();
        members = new List<Member>();
    }
 
    public void AddBook(Book book)
    {
        books.Add(book);
    }
 
    public void RegisterMember(Member member)
    {
        members.Add(member);
    }
 
    public void ListBooks()
    {
        foreach (var book in books)
        {
            book.DisplayDetails();
        }
    }
}
}
