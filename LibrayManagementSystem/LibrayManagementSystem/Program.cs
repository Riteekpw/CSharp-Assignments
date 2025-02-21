// See https://aka.ms/new-console-template for more information
using LibraryManagementSystem.book;
using LibraryManagementSystem.library;
using LibraryManagementSystem.member;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();


        Book book1 = new Book(111,"The Alchemist", "Paulo Coelho", "978-0061122415");
        Book book2 = new Book(112,"1984", "George Orwell", "978-0451524935");
        EBook ebook = new EBook(113,"Digital Fortress", "Dan Brown", "978-0312944926", 2.5, "PDF");


        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(ebook);


        Member member1 = new Member("Alice", 101);
        Member member2 = new Member("Bob", 102);


        library.RegisterMember(member1);
        library.RegisterMember(member2);


        Console.WriteLine("Available Books in Library:");
        library.ListBooks();


        Console.WriteLine("\nBorrowing Books:");
        member1.BorrowBook(book1);
        member2.BorrowBook(book2);
  

        Console.WriteLine("\nReturning Books:");
        member1.ReturnBook(book1);
        member2.ReturnBook(book2);


    }
}

