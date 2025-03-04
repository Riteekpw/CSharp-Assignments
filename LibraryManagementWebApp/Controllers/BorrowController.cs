using LibraryManagementWebApp.Entity;
using LibraryManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementWebApp.Controllers
{
    [ApiController]
    public class BorrowController : ControllerBase
    {
        private readonly IBorrowService _borrowService;

        public BorrowController(IBorrowService borrowService)
        {
            _borrowService = borrowService;
        }

        [Route("borrow-book")]
        [HttpPost]
        public async Task<ActionResult> BorrowBook([FromQuery] int memberId, [FromQuery] int bookId)
        {

                await _borrowService.BorrowBookAsync(memberId, bookId);
                return Ok("Book borrowed successfully.");

        }


        [Route("return-book")]
        [HttpPost]
        public async Task<ActionResult> ReturnBook([FromQuery] int memberId, [FromQuery] int bookId)
        {
                await _borrowService.ReturnBookAsync(memberId, bookId);
                return Ok("Book returned successfully.");
        }
    }
}
