using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Models;
using ContactAppFinal.Exceptions;

namespace ContactAppFinal.Repository
{
    internal class StaffCRUD
    {

        public static Contact AddContact(User user, int contactId, string fName, string lName, bool isActive)
        {
            if (user.Contacts.Any(c => c.ContactId == contactId))
            {
                throw new IdAlreadyExistException($"A contact with ID {contactId} already exists.");
            }

            Contact contact = new Contact(contactId, fName, lName, isActive);
            user.Contacts.Add(contact);
            return contact;
        }

        public static void DisplayContacts(User user)
        {
            if (user.Contacts.Count > 0)
                user.Contacts.ForEach(e => { Console.WriteLine(e); });
            else
                throw new ListEmptyException("Zero Contacts in the List");
        }

        public static void DisplayActiveContacts(User user)
        {
            var activeContacts = user.Contacts.Where(u => u.IsActive).ToList();
            if (activeContacts.Count > 0)
            {
                activeContacts.ForEach(Console.WriteLine);
            }
            else
            {
                throw new ListEmptyException("No active Contacts found in the list.");
            }
        }

        public static Contact UpdateContact(User user, int contactId, string fName, string lName)
        {
            var contact = user.Contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                contact.FName = fName;
                contact.LName = lName;
                return contact;
            }
            else
            {
                throw new NoSuchItemException("No Such Contact in list");
            }
        }

        public static Contact DeleteContact(User user, int contactId)
        {
            var contact = user.Contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                Console.WriteLine(contact);
                contact.IsActive = false;
                return contact;
            }
            else
            {
                throw new NoSuchItemException("No Such Contact in list");
            }
        }


        public static ContactDetail AddContactDetail(Contact contact, int contactDetailId, string type, string email)
        {
            if (contact.ContactDetails.Any(c => c.ContactDetailId == contactDetailId))
            {
                throw new IdAlreadyExistException($"A contact with ID {contactDetailId} already exists.");
            }
            ContactDetail contactDetail = new ContactDetail(contactDetailId, type, email);
            contact.ContactDetails.Add(contactDetail);
            return contactDetail;
        }

        public static void DisplayContactDetails(Contact contact)
        {
            if (contact.ContactDetails.Count > 0)
                contact.ContactDetails.ForEach(e => { Console.WriteLine(e); });
            else
                throw new ListEmptyException("Empty Contact Detail List");
        }

        public static ContactDetail UpdateContactDetail(Contact contact, int contactDetailId, string type, string email)
        {
            var contactDetail = contact.ContactDetails.FirstOrDefault(x => x.ContactDetailId == contactDetailId);
            if (contactDetail != null)
            {
                contactDetail.Type = type;
                contactDetail.Email = email;
                return contactDetail;
            }
            else
            {
                throw new NoSuchItemException("No such detail exists");
            }
        }

        public static void DeleteContactDetail(Contact contact, int contactDetailId)
        {
            var contactDetail = contact.ContactDetails.FirstOrDefault(x => x.ContactDetailId == contactDetailId);
            if (contactDetail != null)
            {
                contact.ContactDetails.Remove(contactDetail);
            }
            else
            {
                throw new NoSuchItemException("No such detail exists");
            }
        }
    }
}
