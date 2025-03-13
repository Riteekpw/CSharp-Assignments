using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Model
{
    public class EBookModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }
        public int EbookId { get; set; }
        public int FileSize { get; set; }
        public string FileFormat { get; set; }
    }
}
