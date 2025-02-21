using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.book;
using LibraryManagementSystem.library;

namespace LibraryManagementSystem.member
{
    abstract class Person
    {
        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Person(string name)
        {
            this.name = name;
        }

        public abstract void BorrowBook(Book book);
        public abstract void ReturnBook(Book book);
    }
}

