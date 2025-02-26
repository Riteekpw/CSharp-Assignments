using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem1.Enitity
{
     class BookRecord
    {
        [Key]
        public int TransactionId { get; set; }

        public int LibrarianId { get; set; }
        public DateTime BorrowedOn { get; set; } = DateTime.Now;
        public DateTime ReturnedOn { get; set; }
        public string BookStatus { get; set; } = "issued";
        public int MappingId { get; set; }
    }
}
