using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    internal class User
    {
        public int UserId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive {  get; set; }
        public List <Contact> Contacts { get; set; }=new List<Contact>();
        
        public static List<User> Users { get; set; } = new List<User>();

        public User(int userId, string fname, string lname, bool isAdmin):this(userId,fname, lname)
        {
         
            IsAdmin = isAdmin;
            IsActive = true;
           
        }
        public User(int userId, string fname, string lname, bool isAdmin, bool isActive) : this(userId, fname, lname, isAdmin)
        {

            IsActive = isActive;

        }
        public User(int userId, string fname, string lname)
        {
            UserId = userId;
            FName = fname;
            LName = lname;
            IsActive = true;
        }
        public User()
        {
            
        }
        public override string ToString()
        {
            return $"User ID: {UserId}\n" +
                $"User Name: {FName+" "+LName}\n" +
                $"isAdmin: {IsAdmin}\n" +
                $"isActive: {IsActive}\n";
        }

    }
}
