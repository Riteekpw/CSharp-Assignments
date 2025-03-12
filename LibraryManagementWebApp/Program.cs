using LibraryManagementWebApp.AuthenticationFilter;
using LibraryManagementWebApp.Data;
using LibraryManagementWebApp.Repository;
using LibraryManagementWebApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Serilog;


public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Host.UseSerilog((context, config) =>
        {
            config
                .Enrich.FromLogContext() 
                .Enrich.WithThreadId()
                .WriteTo.Console()
                .WriteTo.File("logs/myapp.log", rollingInterval: RollingInterval.Day);
        });


        builder.Services.AddDbContext<LibraryContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IBookService, BookService>();
        builder.Services.AddScoped<IMemberService, MemberService>();
        builder.Services.AddScoped<IBorrowService, BorrowService>();
        builder.Services.AddScoped<LibrarianService, LibrarianService>();

        builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.Services.AddScoped<IMemberRepository, MemberRepository>();
        builder.Services.AddScoped<IBorrowRepository, BorrowRepository>();
        builder.Services.AddScoped<LibrarianRepository, LibrarianRepository>();



        builder.Services.AddControllers();




        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("MemberPolicy", policy => policy.RequireRole("Member"));
            options.AddPolicy("LibrarianPolicy", policy => policy.RequireRole("Librarian"));
        });


        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.Logging.AddConsole();


        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });


       // builder.Services.AddTransient<BasicAuthAttribute>();



        var app = builder.Build();

        //for serilog
        app.UseSerilogRequestLogging();


        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }



        app.UseHttpsRedirection();

        app.UseCors("AllowAll");

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<UsernameLoggingMiddleware>();

        app.MapControllers();


        app.Run();
    }
}
