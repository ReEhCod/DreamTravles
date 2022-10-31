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

            Client client = new Client("Gandalf", "password", Enums.Countries.Denmark);

            users.Add(client);
            users.Add(admin);
        }
       


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

        public List<IUser> GetAllUsers()
        {
            return users;
        }
        //public void RemoveUser(IUser)
        //{

        //}
        //public bool UppdateUsername(string IUser)
        //{

        //}
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
        //public bool SignInUser(username, password)
        //{

        //}
    }
}
