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

namespace LibraryMangementWebAppTest.ControllerTests.BooksControllerTests.UpdateBookTests
{
    public class UpdateBooksTests
    {
        private readonly Mock<IBookService> _mockBookService;
        private readonly BooksController _controller;

        public UpdateBooksTests()
        {
            _mockBookService = new Mock<IBookService>();
            _controller = new BooksController(_mockBookService.Object);
        }

        [Fact]
        public async Task UpdateBook_ReturnsOk_WhenBookIsUpdated()
        {
            var bookModel = new BookModel { Title = "Updated Book", Author = "Updated Author", ISBN = "123456" };

            _mockBookService.Setup(s => s.UpdateBookAsync(It.IsAny<Book>())).Returns(Task.CompletedTask);

            var result = await _controller.UpdateBook(bookModel);

            Assert.IsType<OkResult>(result);
        }
    }
}
