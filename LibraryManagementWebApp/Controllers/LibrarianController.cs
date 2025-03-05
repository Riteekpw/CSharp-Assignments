using LibraryManagementWebApp.Entity;
using LibraryManagementWebApp.Model;
using LibraryManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementWebApp.Controllers
{
    [ApiController]
    public class LibrarianController : ControllerBase
    {
        private LibrarianService librarianService;

        public LibrarianController(LibrarianService librarianService)
        {
            this.librarianService = librarianService;
        }

        [Route("librarian-info")]
        [HttpGet]
        public async Task<ActionResult<LibrarianModel>> GetLibrarianInfo()
        {
            var librarian = await librarianService.getLibrarianAsync();
            return Ok(librarian);
        }
    }
}
