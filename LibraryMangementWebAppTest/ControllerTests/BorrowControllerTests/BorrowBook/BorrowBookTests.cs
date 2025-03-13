using LibraryManagementWebApp.Controllers;
using LibraryManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMangementWebAppTest.ControllerTests.BorrowControllerTests.BorrowBook
{
    public class BorrowBookTests
    {
        private readonly Mock<IBorrowService> _mockService;
        private readonly BorrowController _controller;

        public BorrowBookTests()
        {
            _mockService = new Mock<IBorrowService>();
            _controller = new BorrowController(_mockService.Object);
        }

        [Fact]
        public async Task BorrowBook_ReturnsOk_WhenSuccessful()
        {
            int memberId = 1;
            int bookId = 100;
            _mockService.Setup(s => s.BorrowBookAsync(memberId, bookId)).Returns(Task.CompletedTask);

            var result = await _controller.BorrowBook(memberId, bookId);

            var actionResult = Assert.IsType<ActionResult>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal("Book borrowed successfully.", okResult.Value);
        }

        [Fact]
        public async Task BorrowBook_ReturnsNotFound_OnException()
        { 
            int memberId = 1;
            int bookId = 100;
            _mockService.Setup(s => s.BorrowBookAsync(memberId, bookId)).ThrowsAsync(new Exception("Error"));

            var result = await _controller.BorrowBook(memberId, bookId);

            Assert.IsType<NotFoundResult>(result);
        }

    }
}
