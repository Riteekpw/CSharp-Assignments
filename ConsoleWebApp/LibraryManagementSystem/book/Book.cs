using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.book
{
    class Book
    {
        private string title;
        private string author;
        private string isbn;
        private bool available;

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

        public Book(string title, string author, string isbn)
        {
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
