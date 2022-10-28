using DreamTravels.Enums;
using DreamTravels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamTravels.Models
{
    public class Admin : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }


        public Admin(string userame, string password, Countries location)
        {
            Username = Username;
            Password = password;
            Location = location;
        }
    }
}
