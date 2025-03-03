using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Entity
{
    public class MemberMapToBook
    {
        [Key]
        public int MappingId { get; set; }

        public int MemberId { get; set; }
        public int BookId { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        public DateTime BorrowedOn { get; set; } = DateTime.Now;

        public DateTime? ReturnedOn { get; set; }

        public string BookStatus { get; set; } = "issued"; // or "returned"

        public int LibrarianId {  get; set; }
  
        public Librarian Librarian { get; set; }    
    }
}

