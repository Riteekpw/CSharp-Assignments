using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.book;
using LibraryManagementSystem.member;

namespace LibrayManagementSystem.member
{
     interface IMapMember
    {
        public void MapMember(int memberId, int MapEntity);
        public void RemoveMapping(int memberId, int MapEntity);
    }
}
