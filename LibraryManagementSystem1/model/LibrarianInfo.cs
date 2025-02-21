using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrayManagementSystem1.model
{
    public class LibrarianInfo
    {
        [Key]
        public int LibrarianId { get; set; }
        public string LibrarianName { get; set; }

        public virtual ICollection<BookRecord> BookRecords { get; set; } = new List<BookRecord>();
    }
}
