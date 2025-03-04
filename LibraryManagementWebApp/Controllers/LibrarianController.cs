using LibraryManagementWebApp.Entity;
using LibraryManagementWebApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementWebApp.Controllers
{
    [ApiController]
    public class LibrarianController : ControllerBase
    {
        [Route("librarian-info")]
        [HttpGet]
        public async Task<ActionResult<LibrarianModel>> GetLibrarianInfo()
        {
            LibrarianModel librarian = new LibrarianModel();
            librarian.Id = 1;
            librarian.Name = "Ramesh Raghvan";
            librarian.Salary = 10000;
            return Ok(librarian);
        }
    }
}
