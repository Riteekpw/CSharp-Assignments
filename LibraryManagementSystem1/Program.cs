// See https://aka.ms/new-console-template for more information
using LibraryManagementSystem1;
using LibraryManagementSystem1.services;
using LibrayManagementSystem1.model;

class Program
{
    static void Main()
    {
        IBookService bookService = new BookService();
        IMemberService memberService = new MemberService();
        IBorrowService borrowService = new BorrowService();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Add EBook");
            Console.WriteLine("3. List Books");
            Console.WriteLine("4. Register Member");
            Console.WriteLine("5. List Members");
            Console.WriteLine("6. Borrow Book");
            Console.WriteLine("7. Return Book");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Book Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter ISBN: ");
                    string isbn = Console.ReadLine();
                    bookService.AddBookAsync(title, author, isbn);
                    break;
                case "2":
                    Console.Write("Enter EBook Title: ");
                    string eTitle = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    string eAuthor = Console.ReadLine();
                    Console.Write("Enter ISBN: ");
                    string eISBN = Console.ReadLine();
                    Console.Write("Enter File Size (in MB): ");
                    int fileSize = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter File Format: ");
                    string fileFormat = Console.ReadLine();
                    bookService.AddEBookAsync(eTitle, eAuthor, eISBN, fileSize, fileFormat);
                    break;
                case "3":
                    bookService.ListBooksAsync();
                    break;
                case "4":
                    Console.Write("Enter Member Name: ");
                    string memberName = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    memberService.RegisterMemberAsync(memberName, age);
                    break;
                case "5":
                    memberService.ListMembersAsync();
                    break;
                case "6":
                    Console.Write("Enter Member ID: ");
                    int memberId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Book ID: ");
                    int bookId = Convert.ToInt32(Console.ReadLine());
                    borrowService.BorrowBookAsync(memberId, bookId);
                    break;
                case "7":
                    Console.Write("Enter Member ID: ");
                    int mId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Book ID: ");
                    int bId = Convert.ToInt32(Console.ReadLine());
                    borrowService.ReturnBookAsync(mId, bId);
                    break;
                case "8":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
