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
        public override string GetInfo()
        {
            return $"Destination:{Destination} / Country:{Country} / Travelesrs:{Travelers} All inclusive:{AllInclusive}";
        }
    }
}
