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

namespace LibraryMangementWebAppTest.ControllerTests.LibraryControllerTests
{
    public class LibrarianTest
    {
        private readonly Mock<LibrarianService> _mockService;
        private readonly LibrarianController _controller;

        public LibrarianTest()
        {
            _mockService = new Mock<LibrarianService>();
            _controller = new LibrarianController(_mockService.Object);
        }

        [Fact]
        public async Task GetLibrarianInfo_ReturnsOkResult_WithLibrarianData()
        {
            var librarian = new Librarian { Id = 1, Name = "John Doe", Salary = 1000 };
            _mockService.Setup(s => s.getLibrarianAsync()).Returns(Task.FromResult(librarian));

            var result = await _controller.GetLibrarianInfo();

            var actionResult = Assert.IsType<ActionResult<LibrarianModel>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedLibrarian = Assert.IsType<LibrarianModel>(okResult.Value);
            Assert.Equal(librarian.Id, returnedLibrarian.Id);
            Assert.Equal(librarian.Name, returnedLibrarian.Name);
        }

        //[Fact]
        //public async Task GetLibrarianInfo_ReturnsNotFound_WhenNoLibrarian()
        //{
        //    _mockService.Setup(s => s.getLibrarianAsync()).ReturnsAsync((LibrarianModel)null);

        //    var result = await _controller.GetLibrarianInfo();


        //    var actionResult = Assert.IsType<ActionResult<LibrarianModel>>(result);
        //    Assert.IsType<NotFoundResult>(actionResult.Result);
        //}
    }
}
