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

namespace LibraryMangementWebAppTest.ControllerTests.BooksControllerTests.GetBookByIdTests
{
    public class GetBooksByIdTests
    {
        private readonly Mock<IBookService> _mockBookService;
        private readonly BooksController _controller;

        public GetBooksByIdTests()
        {
            _mockBookService = new Mock<IBookService>();
            _controller = new BooksController(_mockBookService.Object);
        }


        [Fact]
        public async Task GetBooksById_ReturnsBook_WithBookId()
        {
            // Arrange
            var book =  new Book { BookId = 1, Title = "Book A", Author = "Author A", ISBN = "123456", IsAvailable = true };


            _mockBookService.Setup(s => s.GetBookByIdAsync(1)).ReturnsAsync(book);

            // Act
            var result = await _controller.GetBookById(1);
            var okResult = result.Result as OkObjectResult;
            var returnedBook = okResult.Value as BookModel;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal("Book A", returnedBook.Title);
        }
    }
}
