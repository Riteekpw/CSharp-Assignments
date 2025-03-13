using LibraryManagementWebApp.Controllers;
using LibraryManagementWebApp.Entity;
using LibraryManagementWebApp.Model;
using LibraryManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMangementWebAppTest.ControllerTests.BooksControllerTests.AddEbookTest
{
    public class AddEBookTests
    {
        private readonly Mock<IBookService> _mockBookService;
        private readonly BooksController _controller;

        public AddEBookTests()
        {
            _mockBookService = new Mock<IBookService>();
            _controller = new BooksController(_mockBookService.Object);
        }

        [Fact]
        public async Task AddEBook_ReturnsOk_WhenEBookIsAdded()
        {
            // Arrange
            var ebookModel = new EBookModel { Title = "E-Book A", Author = "Author A", ISBN = "789456", FileSize = 5, FileFormat = "PDF" };

            _mockBookService.Setup(s => s.AddBookAsync(It.IsAny<Book>())).Returns(Task.CompletedTask);
            _mockBookService.Setup(s => s.AddEBookAsync(It.IsAny<EBook>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.AddEBook(ebookModel);

            // Assert
            Assert.IsType<ActionResult<BookModel>>(result);
        }
    }
}
