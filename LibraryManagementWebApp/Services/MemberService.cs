using LibraryManagementWebApp.Entity;
using LibraryManagementWebApp.Repository;


namespace LibraryManagementWebApp.Services
{
    public class MemberService : IMemberService
    {
        private IMemberRepository memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
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


        public async Task<List<Member>> GetAllMembersAsync()
        {
            return await memberRepository.GetAllAsync();
        }

        public async Task<Member> GetMemberByIdAsync(int id)
        {
            return await memberRepository.FindByIdAsync(id);
        }
    }
}
