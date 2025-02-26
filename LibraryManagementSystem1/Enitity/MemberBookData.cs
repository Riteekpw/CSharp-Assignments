using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem1.Enitity
{
     class MemberBookData
    {
        [Key]
        public int MappingId { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowedOn { get; set; } = DateTime.Now;
        public DateTime ReturnedOn { get; set; }
        public BookStatus Status { get; set; } = BookStatus.Issued;

        public virtual MemberData Member { get; set; }
        public virtual BookData Book { get; set; }
    }
    public enum BookStatus
    {
        Issued,   
        Returned

    }
}
