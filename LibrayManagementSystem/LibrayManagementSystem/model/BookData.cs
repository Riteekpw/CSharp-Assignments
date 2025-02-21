using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrayManagementSystem.model
{
     class BookData
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public bool Available { get; set; }
        public int Rating { get; set; }
        public string IsEbook { get; set; }
        public string IsDeleted { get; set; }
    }
}
