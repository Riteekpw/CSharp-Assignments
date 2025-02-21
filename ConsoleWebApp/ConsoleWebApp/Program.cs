// See https://aka.ms/new-console-template for more information

using ConsoleWebApp.model;

class Program
{
    static void Main(string[] args)
    {
    
        //string name;
        //string email;
        //string password;

        //Console.WriteLine("Enter username:");
        //name = Console.ReadLine();

        //Console.WriteLine("Enter email:");
        //email=Console.ReadLine();

        //Console.WriteLine("Enter password:");
        //password=Console.ReadLine();

        //Console.WriteLine("name is:" + name + "email is:" + email + "Password is :" + password);

        FormData fm = new FormData();

        Console.WriteLine("enter no of users");

        int usersCount = Convert.ToInt32(Console.ReadLine());

        List<FormData> list = new List<FormData>();

        for(int i = 0; i < usersCount; i++)
        {
            FormData formData = new FormData();

            Console.WriteLine("enter Id:");
            formData.Id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter name:");
            formData.Name = Console.ReadLine();

            Console.WriteLine("Enter email:");
            formData.Email = Console.ReadLine();

            Console.WriteLine("Enter password:");
            formData.Password = Console.ReadLine();

            list.Add(formData);
        }



        Console.WriteLine("|--|--------|-------------|-------------|");
        Console.WriteLine("|ID|  NAME  |  Email      | Password    |");

        foreach (var formdata in list) {
            Console.WriteLine("|--|--------|-------------|-------------|");
            Console.WriteLine($"|{formdata.Id} | {formdata.Name} |{formdata.Email} |  {formdata.Password}   |");
        }
        Console.WriteLine("|--|--------|-------------|-------------|");
    }
    
}
