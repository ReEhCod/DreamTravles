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

        //public void Trip(type)
        //{
            
        //}

        public override string GetInfo()
        {
            return "";
        }

    }
}
