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

        //public void Vacation(allInclusive)
        //{

        //}
        public override string GetInfo()
        {
            return "";
        }
    }
}
