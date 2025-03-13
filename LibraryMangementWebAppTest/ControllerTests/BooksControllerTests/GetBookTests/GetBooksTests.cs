using LibraryManagementWebApp.Controllers;
using LibraryManagementWebApp.Entity;
using LibraryManagementWebApp.Model;
using LibraryManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMangementWebAppTest.ControllerTests.BooksControllerTests.GetBookTests
{
    public class GetBooksTests
    {
        private readonly Mock<IBookService> _mockBookService;
        private readonly BooksController _controller;

        public GetBooksTests()
        {
            _mockBookService = new Mock<IBookService>();
            _controller = new BooksController(_mockBookService.Object);
        }


        [Fact]
        public async Task GetBooks_ReturnsOk_WithBooks()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { BookId = 1, Title = "Book A", Author = "Author A", ISBN = "123456", IsAvailable = true },
                new Book { BookId = 2, Title = "Book B", Author = "Author B", ISBN = "654321", IsAvailable = false }
            };

            _mockBookService.Setup(s => s.GetBooksAsync()).ReturnsAsync(books);

            // Act
            var result = await _controller.GetBooks();
            var okResult = result.Result as OkObjectResult;
            var returnedBooks = okResult.Value as List<BookModel>;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(2, returnedBooks.Count);
        }
    }
}
