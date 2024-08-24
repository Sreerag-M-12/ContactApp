using ContactApp.Models;
using ContactAppFinal.Controller;

namespace ContactAppFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User admin1 = new User(101, "Ramesh", "Admin", true,true);
            User admin2 = new User(102, "Rajesh", "Admin", true, false);

            User staff2 = new User(103, "Varun", "Admin", false, true);
            User staff1 = new User(104, "Suresh", "Staff", false, false);
            User.Users.Add(admin1);
            User.Users.Add(staff1);
            User.Users.Add(admin2);
            User.Users.Add(staff2);

            LoginPage.OpenContactMenu();
        }
    }
}
