using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem1.services
{
    public interface IMemberService
    {
        void RegisterMember(string name, int age);
        void ListMembers();
    }
}
