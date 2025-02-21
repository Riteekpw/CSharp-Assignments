using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrayManagementSystem.model
{
     class MemberMapBookData
    {
        public int MappingId {  set; get; }  
        public string MemberId { set; get; }
        public int BookId { set; get; }
        public DateTime  BorrrowedOn { set; get; }
    }
}
