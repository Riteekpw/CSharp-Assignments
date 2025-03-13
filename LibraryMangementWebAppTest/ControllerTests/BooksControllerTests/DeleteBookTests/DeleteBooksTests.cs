using LibraryManagementWebApp.Controllers;
using LibraryManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryMangementWebAppTest.ControllerTests.BooksControllerTests.DeleteBookTests
{
    public class DeleteBooksTests
    {
        private readonly Mock<IBookService> _mockBookService;
        private readonly BooksController _controller;

        public DeleteBooksTests()
        {
            _mockBookService = new Mock<IBookService>();
            _controller = new BooksController(_mockBookService.Object);
        }

        [Fact]
        public async Task DeleteBook_ReturnsOk_WhenBookIsDeleted()
        {
            _mockBookService.Setup(s => s.DeleteBook(It.IsAny<int>())).Returns(Task.CompletedTask);

            var result = await _controller.DeleteBook(1);

            Assert.IsType<OkResult>(result);
        }
    }
}
