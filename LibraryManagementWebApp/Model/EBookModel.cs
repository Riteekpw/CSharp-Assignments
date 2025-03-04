using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Model
{
    public class EBookModel
    {
        public int EbookId { get; set; }
        public int FileSize { get; set; }
        public string FileFormat { get; set; }
    }
}
