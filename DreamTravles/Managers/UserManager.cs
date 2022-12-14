using DreamTravels.Enums;
using DreamTravels.Interfaces;
using DreamTravels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DreamTravels.Managers
{
    public class UserManager
    {
        public IUser SignedInUser { get; set; }
        public List<IUser> users = new();

        public UserManager()
        {
            Admin admin = new Admin("admin", "password", Enums.Countries.Sweden);

            Client client = new Client("Gandalf", "password", Enums.Countries.Norway);

            users.Add(client);
            users.Add(admin);
        }
       

        // Adds the user to the app
        public bool AddUser(string username, string password, Countries location)
        {
            if(ValidateUsername(username))
            {
                Client client = new(username, password, location);

                users.Add(client);

                return true;
            }

            return false;
        }

        // Returns all users
        public List<IUser> GetAllUsers()
        {
            return users;
        }

        // Updates the specific users information
        public void UppdateUser(IUser userToUpdate, string newUsername, string newPassword, Countries newLocation)
        {
            int userIndex = users.FindIndex(user => user.Username.Equals(userToUpdate.Username));
            users[userIndex].Username = newUsername;
            SignedInUser.Username = newUsername;

            int userIndex1 = users.FindIndex(user => user.Password.Equals(userToUpdate.Password));
            users[userIndex1].Password = newPassword;
            SignedInUser.Password = newPassword;

            int userIndex2 = users.FindIndex(user => user.Location.Equals(userToUpdate.Location));
            users[userIndex2].Location = newLocation;
            SignedInUser.Location = newLocation;
        }

        // It checks if the username already exist in the system
        private bool ValidateUsername(string usernameToValidate)
        {
            // Loopa igenom alla users
            foreach (IUser user in users)
            {
                // Kolla om det finns någon user som har användarnamnet
                if (user.Username == usernameToValidate)
                {
                    // Om användarnamnet är upptaget - returnera false
                    MessageBox.Show("Invalid username or taken!", "Warning!");
                    return false;
                    
                }
            }
            
            
            // Om användarnamnet är ledigt - returnera true
            return true;
        }

    }
}
