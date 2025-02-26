using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem1.data;
using LibraryManagementSystem1.repository;
using LibrayManagementSystem1.model;

namespace LibraryManagementSystem1.services
{
    public class MemberService : IMemberService
    {
        private  IMemberRepository memberRepository;
        private  LibraryDbContext _context;
        private IMemberRepository @object;

        public MemberService()
        {
            _context = new LibraryDbContext();
            memberRepository = new MemberRepository(_context);
        }

        public MemberService(IMemberRepository @object)
        {
            this.@object = @object;
        }

        public async Task RegisterMemberAsync(string name, int age)
        {
            var member = new Member
            {
                Name = name,
                Age = age,
                IsDeleted = false
            };

            await memberRepository.AddAsync(member);
            await memberRepository.SaveChangesAsync();
            Console.WriteLine($"Member '{member.Name}' registered with ID: {member.MemberId}");
        }

        public async Task ListMembersAsync()
        {
            var members = await memberRepository.GetAllAsync();
            Console.WriteLine("\nList of Members:");
            foreach (var member in members)
            {
                Console.WriteLine($"ID: {member.MemberId}, Name: {member.Name}, Age: {member.Age}");
            }
        }
    }
}
