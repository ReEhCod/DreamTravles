using DreamTravels.Enums;
using DreamTravels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamTravels.Models
{
    public class Client : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }
        public List<Travel> Travels { get; set; } = new();
        public bool IsAdmin { get; set; }

        public Client(string userame, string password, Countries location)
        {
            Username = userame; 
            Password = password;
            Location = location;
        }
    }
}
