using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Models;
using ContactAppFinal.Exceptions;
using ContactAppFinal.Repository;

namespace ContactAppFinal.Controller
{
    internal class StaffMenu
    {
        public static void OpenStaffMenu(User user)
        {
            while (true)
            {
                Console.WriteLine("Welcome to Staff Control");
                Console.WriteLine("What operation would you like to perform? \n" +
                    "1. Add Contact               2. Display Contacts\n" +
                    "3. Display Active Contacts   4. Update Contact\n" +
                    "5. Delete Contact            6. Add Contact Details\n" +
                    "7. Display Contact Details   8. Update Contact Details\n" +
                    "9. Delete Contact Details    10. Exit \n"
                    );

                Console.WriteLine("Enter your Choice");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
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
                catch (IdAlreadyExistException iae)
                {
                    Console.WriteLine(iae.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void DoTask(User user, int choice)
        {
            switch (choice)
            {
                case 1:
                    AddContact(user);
                    break;
                case 2:
                    DisplayContacts(user);
                    break;
                case 3:
                    DisplayActiveContacts(user);
                    break;
                case 4:
                    UpdateContact(user);
                    break;
                case 5:
                    DeleteContact(user);
                    break;
                case 6:
                    AddContactDetail(user);
                    break;
                case 7:
                    DisplayContactDetails(user);
                    break;
                case 8:
                    UpdateContactDetail(user);
                    break;
                case 9:
                    DeleteContactDetail(user);
                    break;
                case 10:
                    LoginPage.OpenContactMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }

        private static void AddContact(User user)
        {
            Console.WriteLine("Enter Contact Id");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter First Name");
            string fname = Console.ReadLine()!;
            Console.WriteLine("Enter Last Name");
            string lname = Console.ReadLine()!;
            Contact contact = StaffCRUD.AddContact(user, contactId, fname, lname, true);
            Console.WriteLine("Contact added successfully");
        }

        private static void DisplayContacts(User user)
        {
            Console.WriteLine("Contacts Available:");
            StaffCRUD.DisplayContacts(user);
        }
        private static void DisplayActiveContacts(User user)
        {
            Console.WriteLine("Contacts Available:");
            StaffCRUD.DisplayActiveContacts(user);
        }


        private static void UpdateContact(User user)
        {
            Console.WriteLine("Enter Contact Id");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter First Name");
            string fname = Console.ReadLine()!;
            Console.WriteLine("Enter Last Name");
            string lname = Console.ReadLine()!;
            Contact contact = StaffCRUD.UpdateContact(user, contactId, fname, lname);
            Console.WriteLine("Contact Updated");
        }

        private static void DeleteContact(User user)
        {
            Console.WriteLine("Enter Contact Id to Delete");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Contact contact = StaffCRUD.DeleteContact(user, contactId);
            Console.WriteLine("Contact Deleted");
        }

        private static void AddContactDetail(User user)
        {
            Console.WriteLine("Enter Contact Id for the detail");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Contact Detail Id");
            int contactDetailId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Type");
            string type = Console.ReadLine()!;
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine()!;
            Contact contact = user.Contacts.FirstOrDefault(c => c.ContactId == contactId);
            if (contact != null)
            {
                ContactDetail contactDetail = StaffCRUD.AddContactDetail(contact, contactDetailId, type, email);
                Console.WriteLine("Added Successfully");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        private static void DisplayContactDetails(User user)
        {
            Console.WriteLine("Enter Contact Id to display details");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Contact contact = user.Contacts.FirstOrDefault(c => c.ContactId == contactId);
            if (contact != null)
            {
                StaffCRUD.DisplayContactDetails(contact);
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        private static void UpdateContactDetail(User user)
        {
            Console.WriteLine("Enter Contact Id");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Contact Detail Id");
            int contactDetailId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Type");
            string type = Console.ReadLine()!;
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine()!;
            Contact contact = user.Contacts.FirstOrDefault(c => c.ContactId == contactId);
            if (contact != null)
            {
                ContactDetail contactDetail = StaffCRUD.UpdateContactDetail(contact, contactDetailId, type, email);
                Console.WriteLine("Updated");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        private static void DeleteContactDetail(User user)
        {
            Console.WriteLine("Enter Contact Id to delete details from");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Contact Detail Id to delete");
            int contactDetailId = Convert.ToInt32(Console.ReadLine());
            Contact contact = user.Contacts.FirstOrDefault(c => c.ContactId == contactId);
            if (contact != null)
            {
                StaffCRUD.DeleteContactDetail(contact, contactDetailId);
                Console.WriteLine("Deleted");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        

    }
}
