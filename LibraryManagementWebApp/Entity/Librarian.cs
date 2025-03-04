namespace LibraryManagementWebApp.Entity
{
    public class Librarian
    {
        public int Id { get; set; }
        public string Name { get; set; } 

        public int Salary { get; set; } 

        public virtual MemberMapToBook MemberMapToBook { get; set; }
    }
}
