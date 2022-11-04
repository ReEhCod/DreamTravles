using DreamTravels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamTravels.Models
{
    public class Trip : Travel
    {
        public TripeTypes Type { get; set; }
        public Trip(string destination, Countries country, int travelers, TripeTypes tripType) : base(destination, country, travelers)
        {
            this.Type = tripType;
        }

        // Gets the travel information if it's a trip
        public override string GetInfo()
        {
            return $"Destination: {Destination}\nCountry: {Country}\nTravelesrs: {Travelers}\nType: {Type}";
        }

    }
}
