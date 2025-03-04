using LibraryManagementWebApp.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementWebApp.Model
{
    public class MemberMapToBookModel
    {
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public int LibrarianId { get; set; }
    }
}
