using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.book
{
    class Book
    {
        private int bookId;
        private string title;
        private string author;
        private string isbn;
        private bool available;

        public int BookId
        {
            get { return bookId; }
            set { bookId = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public bool Available
        {
            get { return available; }
            set { available = value; }
        }

        public Book(int bookId,string title, string author, string isbn)
        {  
            this.bookId = bookId;
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.available = true;
        }


        public void DisplayDetails()
        {
            Console.WriteLine($"Title: {title}, Author: {author}, ISBN: {isbn}, Available: {available}");
        }

        public void BorrowBook()
        {
            if (available)
            {
                available = false;
                Console.WriteLine($"{title} has been borrowed.");
            }
            else
            {
                Console.WriteLine($"{title} is not available.");
            }
        }

        public void ReturnBook()
        {
            available = true;
            Console.WriteLine($"{title} has been returned.");
        }
    }
}
