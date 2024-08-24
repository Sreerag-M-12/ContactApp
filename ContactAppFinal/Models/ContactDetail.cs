using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    internal class ContactDetail
    {
        public int ContactDetailId { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }

        public ContactDetail(int id, string type, string email)
        {
            ContactDetailId = id;
            Type = type;
            Email = email;
        }
        public override string ToString()
        {
            return $"Contact Detail ID {ContactDetailId}\n" +
                $"Type: {Type}\n" +
                $"Email: {Email}\n";
        }
    }
}
