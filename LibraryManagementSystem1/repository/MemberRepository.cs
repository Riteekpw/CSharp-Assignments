using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem1.data;
using LibrayManagementSystem1.model;

namespace LibraryManagementSystem1.repository
{
    public class MemberRepository : IMemberRepository
    {
        private  LibraryDbContext context;

        public MemberRepository(LibraryDbContext context)
        {
            this.context = context;
        }

        public void Add(Member member)
        {
            context.Members.Add(member);
        }

        public Member FindById(int memberId)
        {
            return context.Members.Find(memberId);
        }

        public IEnumerable<Member> GetAll()
        {
            return context.Members.ToList();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
