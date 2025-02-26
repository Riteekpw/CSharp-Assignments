using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem1.Enitity
{
     class Ebook
    {
        [Key]
        public int EbookId { get; set; }
        public int FileSize { get; set; }
        public string FileFormat { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
