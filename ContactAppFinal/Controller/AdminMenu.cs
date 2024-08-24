using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ContactApp.Models;
using ContactAppFinal.Exceptions;
using ContactAppFinal.Repository;

namespace ContactAppFinal.Controller
{
    internal class AdminMenu
    {
        public static void OpenAdminMenu(User user)
        {
            while (true)
            {
                Console.WriteLine("Welcome to Admin Control");
                Console.WriteLine("What operation would you like to perform? \n" +
                    "1. Add new Admin \n" +
                    "2. Add new Staff\n" +
                    "3. Display Users\n" +
                    "4. Update User\n" +
                    "5. Delete User\n" +
                    "6. Display Active Users\n" +
                    "7. Exit \n");

                Console.WriteLine("Enter your Choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                try
                {
                    DoTask(user, choice);
                }
                catch (ListEmptyException le)
                {
                    Console.WriteLine(le.Message);
                }
                catch (NoSuchItemException nsie)
                {
                    Console.WriteLine(nsie.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    break; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void DoTask(User currentUser, int choice)
        {
            switch (choice)
            {
                case 1:
                    AddAdmin(currentUser);
                    break;
                case 2:
                    AddStaff(currentUser);
                    break;
                case 3:
                    Console.WriteLine("Available Users");
                    AdminCRUD.DisplayUser(currentUser);
                    break;
                case 4:
                    Update(currentUser);
                    break;
                case 5:
                    Delete(currentUser);
                    break;
                case 6:
                    Console.WriteLine("Active Users");
                    AdminCRUD.DisplayActiveUsers(currentUser);
                    break;
                case 7:
                    LoginPage.OpenContactMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }

        private static void AddAdmin(User currentUser)
        {
            Console.WriteLine("Enter new Admin Id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter First Name");
            string fname = Console.ReadLine()!;
            Console.WriteLine("Enter Last Name");
            string lname = Console.ReadLine()!;
            AdminCRUD.AddAdmin(currentUser, userId, fname, lname);
            Console.WriteLine("Added New Admin");
        }

        private static void AddStaff(User currentUser)
        {
            Console.WriteLine("Enter Staff Id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter First Name");
            string fname = Console.ReadLine()!;
            Console.WriteLine("Enter Last Name");
            string lname = Console.ReadLine()!;
            AdminCRUD.AddStaff(currentUser, userId, fname, lname);
            Console.WriteLine("Added New Staff");
        }

        private static void Update(User currentUser)
        {
            Console.WriteLine("Enter User Id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter First Name");
            string fname = Console.ReadLine()!;
            Console.WriteLine("Enter Last Name");
            string lname = Console.ReadLine()!;
            var user = AdminCRUD.UpdateUser(currentUser, userId, fname, lname);
            Console.WriteLine("Updated User");
        }

        private static void Delete(User currentUser)
        {
            Console.WriteLine("Enter User Id");
            int userId = Convert.ToInt32(Console.ReadLine());
            AdminCRUD.DeleteUser(currentUser, userId);
            Console.WriteLine("Deleted User");
        }
    }
}
