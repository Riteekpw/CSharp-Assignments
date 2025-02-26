using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem1.Enitity
{
     class MemberData
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsDeleted { get; set; } = true;

        public virtual ICollection<MemberBookData> MemberBooks { get; set; } = new List<MemberBookData>();
    }
}
