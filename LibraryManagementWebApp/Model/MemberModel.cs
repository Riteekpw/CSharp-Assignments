using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Model
{
    public class MemberModel
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
