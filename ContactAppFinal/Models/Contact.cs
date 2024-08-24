using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    internal class Contact
    {
        public int ContactId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public bool IsActive { get; set; }
        public int staffId { get; set; }
        public  List<ContactDetail> ContactDetails { get; set; } = new List<ContactDetail>();
        
        public Contact()
        {
            
        }
        public Contact(int contactId, string fName, string lName, bool isActive)
        {
            ContactId = contactId;
            FName = fName;
            LName = lName;
            IsActive = isActive;
            
          //  ContactDetails = contactDetails;
        }
        public Contact(int contactId, string fName, string lName)
        {
            ContactId = contactId;
            FName = fName;
            LName = lName;
            
            //  ContactDetails = contactDetails;
        }

        public override string ToString()
        {
            return $"Contact ID: {ContactId}\n" +
                $"Name: {FName + " " + LName}\n" +
                $"isActive: {IsActive}\n";
        }

    }
}
