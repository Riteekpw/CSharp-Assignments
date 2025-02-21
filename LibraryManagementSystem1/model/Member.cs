using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrayManagementSystem1.model
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsDeleted { get; set; } = true;

        public virtual ICollection<MemberBook> MemberBooks { get; set; } = new List<MemberBook>();
    }
}
