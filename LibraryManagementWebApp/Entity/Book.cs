using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Entity
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string ISBN { get; set; }

        public bool IsAvailable { get; set; } = true;

        public string IsEBook { get; set; } = "false";

        public bool IsDeleted { get; set; } = false;

        public virtual EBook EBook { get; set; }
    }
}
