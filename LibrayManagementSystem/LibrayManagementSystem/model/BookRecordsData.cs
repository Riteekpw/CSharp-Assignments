using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrayManagementSystem.model
{
     class BookRecordsData
    {
        public int TransactionId {  get; set; }
        public int LibrarianId {  get; set; }
        public DateTime BorrowedOn { get; set; }
        public DateTime ReturnedOn { get; set; }
        public string BookStatus { get; set; }
        public int MappingId { get; set; }
    }
}
