using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrayManagementSystem1.model
{
    public class MemberBook
    {
        [Key]
        public int MappingId { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowedOn { get; set; } = DateTime.Now;
        public DateTime ReturnedOn { get; set; }
        public string BookStatus { get; set; } = "issued";
        public virtual Member Member { get; set; }
        public virtual Book Book { get; set; }
    
    }
}
