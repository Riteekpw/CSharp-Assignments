using LibraryManagementWebApp.Entity;
using LibraryManagementWebApp.Model;
using LibraryManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementWebApp.Controllers
{
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> RegisterMember([FromBody] MemberModel member)
        {
            if (member == null || string.IsNullOrWhiteSpace(member.Name) || member.Age <= 0)
            {
                return BadRequest("Invalid member data.");
            }

            await _memberService.RegisterMemberAsync(member.Name, member.Age);
            return Ok($"Member {member.Name} registered successfully.");

        }



        [Route("list")]
        [HttpGet]
        public async Task<ActionResult<List<MemberModel>>> GetMembers()
        {
                var members = await _memberService.GetAllMembersAsync();
                return Ok(members);
        }


        [Route("getmember/{id}")]
        [HttpGet]
        public async Task<ActionResult<MemberModel>> GetMemberById(int id)
        {
            var member = await _memberService.GetMemberByIdAsync(id);

            if (member == null)
            {
                return NotFound(); 
            }

            var memberModel = new MemberModel
            {
                MemberId = member.MemberId,
                Name = member.Name,
                Age = member.Age
            };

            return Ok(memberModel); 
        }

    }
}

