﻿using System;
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
        private  LibraryDbContext context;

        public MemberService()
        {
            context = new LibraryDbContext();
            memberRepository = new MemberRepository(context);
        }

        public void RegisterMember(string name, int age)
        {
            var member = new Member
            {
                Name = name,
                Age = age,
                IsDeleted = false
            };

            memberRepository.Add(member);
            memberRepository.SaveChanges();
            Console.WriteLine($"Member '{member.Name}' registered with ID: {member.MemberId}");
        }

        public void ListMembers()
        {
            var members = memberRepository.GetAll().ToList();
            Console.WriteLine("\nList of Members:");
            foreach (var member in members)
            {
                Console.WriteLine($"ID: {member.MemberId}, Name: {member.Name}, Age: {member.Age}");
            }
        }
    }
}
