using LibraryManagementWebApp.Controllers;
using LibraryManagementWebApp.Entity;
using LibraryManagementWebApp.Model;
using LibraryManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMangementWebAppTest.ControllerTests.MemberControllerTests.GetMemberById
{
    public class GetMemberByIdTests
    {
        private readonly Mock<IMemberService> _mockService;
        private readonly Mock<ILogger<MemberController>> _mockLogger;
        private readonly MemberController _controller;

        public GetMemberByIdTests()
        {
            _mockService = new Mock<IMemberService>();
            _mockLogger = new Mock<ILogger<MemberController>>();
            _controller = new MemberController(_mockService.Object, _mockLogger.Object);
        }


        [Fact]
        public async Task GetMemberById_ReturnsOk_WhenMemberExists()
        {

            int memberId = 1;
            var member = new Member { MemberId = memberId, Name = "John Doe", Age = 25 };

            _mockService.Setup(s => s.GetMemberByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(member));


            var result = await _controller.GetMemberById(memberId);

            var actionResult = Assert.IsType<ActionResult<MemberModel>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedMember = Assert.IsType<MemberModel>(okResult.Value);
            Assert.Equal(memberId, returnedMember.MemberId);
        }

        [Fact]
        public async Task GetMemberById_ReturnsNotFound_WhenMemberDoesNotExist()
        {
      
            int memberId = 1;
            _mockService.Setup(s => s.GetMemberByIdAsync(memberId)).Returns((MemberModel)null);

            var result = await _controller.GetMemberById(memberId);

    
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
