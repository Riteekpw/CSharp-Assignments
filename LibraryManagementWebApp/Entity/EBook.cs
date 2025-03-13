using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Entity
{
    public class EBook
    {
        [Key]
        public int EbookId { get; set; }

        public int FileSize { get; set; }

        [Required]
        public string FileFormat { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
    }
}
