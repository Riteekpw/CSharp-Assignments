using LibraryManagementWebApp.Controllers;
using LibraryManagementWebApp.Entity;
using LibraryManagementWebApp.Model;
using LibraryManagementWebApp.Repository;
using LibraryManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryMangementWebAppTest.ControllerTests.BooksControllerTests.AddBookTests
{
    public class AddBooksTests
    {
        private readonly Mock<IBookService> _mockBookService;
        private readonly BooksController _controller;

        public AddBooksTests()
        {
            _mockBookService = new Mock<IBookService>();
            _controller = new BooksController(_mockBookService.Object);
        }

        [Fact]
        public async Task AddBOOK_ReturnsOk_WhenBookIsAdded()
        {
            var bookModel = new BookModel { Title = "Book A", Author = "Author A", ISBN = "123456" };

            _mockBookService.Setup(s => s.AddBookAsync(It.IsAny<Book>())).Returns(Task.CompletedTask);

            var result = await _controller.AddBook(bookModel);

            Assert.IsType<ActionResult<BookModel>>(result);
        }
    }
}
