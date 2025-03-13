using LibraryManagementWebApp.Controllers;
using LibraryManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMangementWebAppTest.ControllerTests.BorrowControllerTests.ReturnBook
{
    public class ReturnBookTests
    {
        private readonly Mock<IBorrowService> _mockService;
        private readonly BorrowController _controller;

        public ReturnBookTests()
        {
            _mockService = new Mock<IBorrowService>();
            _controller = new BorrowController(_mockService.Object);
        }


        [Fact]
        public async Task ReturnBook_ReturnsOk_WhenSuccessful()
        {
    
            int memberId = 1;
            int bookId = 100;
            _mockService.Setup(s => s.ReturnBookAsync(memberId, bookId)).Returns(Task.CompletedTask);

            var result = await _controller.ReturnBook(memberId, bookId);

            var actionResult = Assert.IsType<ActionResult>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal("Book returned successfully.", okResult.Value);
        }

        [Fact]
        public async Task ReturnBook_ReturnsNotFound_OnException()
        {
            int memberId = 1;
            int bookId = 100;
            _mockService.Setup(s => s.ReturnBookAsync(memberId, bookId)).ThrowsAsync(new Exception("Error"));

            var result = await _controller.ReturnBook(memberId, bookId);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}

