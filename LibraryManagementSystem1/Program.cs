// See https://aka.ms/new-console-template for more information
using System;
using LibraryManagementSystem1;
using LibraryManagementSystem1.data;
using LibraryManagementSystem1.repository;
using LibraryManagementSystem1.services;
using LibrayManagementSystem1.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

class Program
{
    static async Task Main(string[] args)
    {

        //Log.Logger = new LoggerConfiguration()
        //    .MinimumLevel.Information()
        //    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
        //    .CreateLogger();

        //Log.Logger = new LoggerConfiguration()
        //    .MinimumLevel.Information()
        //    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
        //    .CreateLogger();

        Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()  // Set the minimum log level (Information, in your case)
    .WriteTo.Console()           // Log to the console
    .CreateLogger();

        var services = new ServiceCollection();

        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog();
        });

        services.AddDbContext<LibraryDbContext>(options =>
        options.UseSqlServer("Server=P2021-PC00312\\SQLEXPRESS;Database=Library;Trusted_Connection=True;TrustServerCertificate=True"));

        services.AddSingleton<IBookService, BookService>();
        services.AddSingleton<IMemberService, MemberService>();
        services.AddSingleton<IBorrowService, BorrowService>();

        services.AddSingleton<IBookRepository, BookRepository>();
        services.AddSingleton<IMemberRepository, MemberRepository>();
        services.AddSingleton<IBorrowRepository, BorrowRepository>();

        // 3. Build the service provider from the service collection.
        var serviceProvider = services.BuildServiceProvider();

        // 4. Resolve the services that you need.
        var bookService = serviceProvider.GetRequiredService<IBookService>();
        var memberService = serviceProvider.GetRequiredService<IMemberService>();
        var borrowService = serviceProvider.GetRequiredService<IBorrowService>();


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
