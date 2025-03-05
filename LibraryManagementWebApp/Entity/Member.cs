using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Entity
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<MemberMapToBook> BorrowedBooks { get; set; }
    }
}
