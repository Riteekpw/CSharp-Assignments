using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Model
{
    public class BookModel
    {

        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public bool IsAvailable { get; set; } = true;

        public string IsEBook { get; set; } = "false";
    }
}
