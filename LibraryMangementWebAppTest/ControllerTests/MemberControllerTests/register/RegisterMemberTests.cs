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

namespace LibraryMangementWebAppTest.ControllerTests.MemberControllerTests.register
{
    public class RegisterMemberTests
    {
        private readonly Mock<IMemberService> _mockService;
        private readonly Mock<ILogger<MemberController>> _mockLogger;
        private readonly MemberController _controller;

        public RegisterMemberTests()
        {
            _mockService = new Mock<IMemberService>();
            _mockLogger = new Mock<ILogger<MemberController>>();
            _controller = new MemberController(_mockService.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task RegisterMember_ReturnsOk_WhenSuccessful()
        {
            var member = new MemberModel { Name = "John Doe", Age = 25 };
            _mockService.Setup(s => s.RegisterMemberAsync(member.Name, member.Age)).Returns(Task.CompletedTask);

            var result = await _controller.RegisterMember(member);

            var actionResult = Assert.IsType<ActionResult>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal($"Member {member.Name} registered successfully.", okResult.Value);
        }


        [Fact]
        public async Task RegisterMember_ReturnsBadRequest_WhenInvalidData()
        {
            var invalidMember = new MemberModel { Name = "", Age = -1 };

            var result = await _controller.RegisterMember(invalidMember);

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
