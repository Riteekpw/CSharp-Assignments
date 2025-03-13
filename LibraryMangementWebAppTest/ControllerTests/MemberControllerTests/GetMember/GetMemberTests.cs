using LibraryManagementWebApp.Controllers;
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

namespace LibraryMangementWebAppTest.ControllerTests.MemberControllerTests.GetMember
{
    public class GetMemberTests
    {
        private readonly Mock<IMemberService> _mockService;
        private readonly Mock<ILogger<MemberController>> _mockLogger;
        private readonly MemberController _controller;

        public GetMemberTests()
        {
            _mockService = new Mock<IMemberService>();
            _mockLogger = new Mock<ILogger<MemberController>>();
            _controller = new MemberController(_mockService.Object, _mockLogger.Object);
        }



        [Fact]
        public async Task GetMembers_ReturnsOk_WithMemberList()
        {
            // Arrange
            var members = new List<MemberModel>
        {
            new MemberModel { MemberId = 1, Name = "John Doe", Age = 25 },
            new MemberModel { MemberId = 2, Name = "Jane Doe", Age = 30 }
        };

            _mockService.Setup(s => s.GetAllMembersAsync()).Returns(members);

            var result = await _controller.GetMembers();

            var actionResult = Assert.IsType<ActionResult<List<MemberModel>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedMembers = Assert.IsType<List<MemberModel>>(okResult.Value);
            Assert.Equal(2, returnedMembers.Count);
        }


        [Fact]
        public async Task GetMembers_ReturnsNotFound_WhenNoMembersExist()
        {
            // Arrange
            _mockService.Setup(s => s.GetAllMembersAsync()).Returns((List<MemberModel>)null);

            // Act
            var result = await _controller.GetMembers();

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
