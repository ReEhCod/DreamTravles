using DreamTravels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamTravels.Models
{
    public class Travel
    {
        public string Destination { get; set; }
        public Countries Country { get; set; }
        public int Travelers { get; set; }

        //public void Travel()
        //{

        //}
        public virtual string GetInfo()
        {
            return "";
        }
    }
}
