using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrayManagementSystem1.model;

namespace LibraryManagementSystem1.repository
{
    public interface IMemberRepository
    {
        void Add(Member member);
        Member FindById(int memberId);
        IEnumerable<Member> GetAll();
        void SaveChanges();
    }
}
