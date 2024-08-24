using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Models;

namespace ContactAppFinal.Controller
{
    internal class LoginPage
    {
        public static void OpenContactMenu()
        {
            while (true)
            {

                Console.WriteLine("Welcome to Contact App");
                Console.WriteLine("Enter your Choice");


                Console.WriteLine("What operation would you like to perform? \n" +
                   "1. Login\n" +
                   "2. Exit\n");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    DoTask(choice);
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message); 
                }
            }
                
        }

        public static void DoTask(int choice)
        {
            switch (choice)
            {

                case 1:
                    Console.WriteLine("Enter User Id \n");

                    int userId = Convert.ToInt32(Console.ReadLine());
                    var user = User.Users.FirstOrDefault(x => x.UserId == userId);
                    if (user != null)
                    {
                        if (user.IsActive == true)
                        {
                            if (user.IsAdmin == true)
                                AdminMenu.OpenAdminMenu(user);
                            else
                                StaffMenu.OpenStaffMenu(user);
                        }
                        else
                        {
                            Console.WriteLine("User is Inactive");
                        }
                    }
                    else
                    {
                        Console.WriteLine("User Id is Invalid");
                    }
                break;

                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

        }
    }
}
