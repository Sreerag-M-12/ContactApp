using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Models;
using ContactAppFinal.Exceptions;

namespace ContactAppFinal.Repository
{
    internal class AdminCRUD
    {
        private static void ValidateUserIsActive(User user)
        {
            if (!user.IsActive)
            {
                throw new InvalidOperationException("The current user is deactivated and cannot perform any actions.");
            }
        }

        public static User UserExists(int userId)
        {
            return User.Users.FirstOrDefault(u => u.UserId == userId);
        }

        public static void AddStaff(User currentUser, int userId, string fName, string lName)
        {
            ValidateUserIsActive(currentUser);

            if (User.Users.Any(c => c.UserId == userId))
            {
                throw new IdAlreadyExistException($"A contact with ID {userId} already exists.");
            }
            User user = new User(userId, fName, lName, false);
            User.Users.Add(user);
        }

        public static void AddAdmin(User currentUser, int userId, string fName, string lName)
        {
            ValidateUserIsActive(currentUser);
            if (User.Users.Any(c => c.UserId == userId))
            {
                throw new IdAlreadyExistException($"A contact with ID {userId} already exists.");
            }
            User user = new User(userId, fName, lName, true);
            User.Users.Add(user);
        }

        public static void DisplayUser(User currentUser)
        {
            ValidateUserIsActive(currentUser);
            if (User.Users.Count != 0)
                User.Users.ForEach(Console.WriteLine);
            else
                throw new ListEmptyException("Zero Users in the List");
        }

        public static void DisplayActiveUsers(User currentUser)
        {
            ValidateUserIsActive(currentUser);
            var activeUsers = User.Users.Where(u => u.IsActive).ToList();
            if (activeUsers.Count > 0)
            {
                activeUsers.ForEach(Console.WriteLine);
            }
            else
            {
                throw new ListEmptyException("No active users found in the list.");
            }
        }

        public static User UpdateUser(User currentUser, int userId, string fName, string lName)
        {
            ValidateUserIsActive(currentUser);
            var user = UserExists(userId);
            if (user != null)
            {
                user.FName = fName;
                user.LName = lName;
                return user;
            }
            else
            {
                throw new NoSuchItemException("No such user in the list");
            }
        }

        public static User DeleteUser(User currentUser, int id)
        {
            ValidateUserIsActive(currentUser);
            var user = UserExists(id);
            if (user != null)
            {
                user.IsActive = false;
                return user;
            }
            else
            {
                throw new NoSuchItemException("No such User exists");
            }
        }
    }
}
