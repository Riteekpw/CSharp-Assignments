using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrayManagementSystem1.model
{
    public class Ebook
    {
        [Key]
        public int EbookId { get; set; }
        public int FileSize { get; set; }
        public string FileFormat { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        /* virtual :It allows the Entity Framework to create a proxy around the virtual 
          property so that the property can support lazy loading and more efficient change tracking.*/
    }
}
