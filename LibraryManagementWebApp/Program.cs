using LibraryManagementWebApp.Data;
using LibraryManagementWebApp.Repository;
using LibraryManagementWebApp.Services;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddDbContext<LibraryContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IBookService, BookService>();
        builder.Services.AddScoped<IMemberService, MemberService>();
        builder.Services.AddScoped<IBorrowService, BorrowService>();

        builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.Services.AddScoped<IMemberRepository, MemberRepository>();
        builder.Services.AddScoped<IBorrowRepository, BorrowRepository>();


        builder.Services.AddControllers();

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


        var app = builder.Build();


        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }



        app.UseHttpsRedirection();

        app.UseCors("AllowAll");

        app.UseAuthorization();


        app.MapControllers();


        app.Run();
    }
}
