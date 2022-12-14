using DreamTravels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamTravels.Models
{
    public class Vacation : Travel
    {
        public bool AllInclusive { get; set; }

        public Vacation(string destination, Countries country, int travelers, bool allInclusive) : base(destination, country, travelers)
        {
            AllInclusive = allInclusive;
        }

        // Gets travel information if it's a vaccation
        public override string GetInfo()
        {
            return $"Destination: {Destination}\nCountry: {Country}\nTravelesrs: {Travelers}\nAll inclusive: {AllInclusive}";
        }
    }
}
