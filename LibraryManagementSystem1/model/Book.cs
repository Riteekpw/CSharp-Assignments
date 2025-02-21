using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrayManagementSystem1.model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int Rating { get; set; }
        public string IsEbook { get; set; }
        public bool IsDeleted { get; set; } = true;

        public virtual Ebook Ebook { get; set; }

        public void DisplayDetails()
        {
            Console.WriteLine($"Id:{BookId}, Title:{Title}, Author:{Author}, ISBN:{ISBN} ,IsAvailable:{IsAvailable},Rating:{Rating},IsEbook:{IsEbook},IsDeleted:{IsDeleted}");
        }
    }
}
