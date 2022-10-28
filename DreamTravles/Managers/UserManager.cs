using DreamTravels.Enums;
using DreamTravels.Interfaces;
using DreamTravels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamTravels.Managers
{
    public class UserManager
    {
        public IUser SignedInUser { get; set; }
        public List<IUser> users = new();

        public UserManager()
        {
            Admin admin = new Admin("admin", "password", Enums.Countries.Sweden);

            Client client = new Client("Gandalf","password", Enums.Countries.Afghanistan);

            users.Add(client);
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
            // Kolla om det finns någon user som har användarnamnet
            // Om användarnamnet är upptaget - returnera false
            // Om användarnamnet är ledigt - returnera true
        }
        //public bool SignInUser(username, password)
        //{

        //}
    }
}
