using DreamTravels.Enums;
using DreamTravels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DreamTravels.Managers
{
    public class TravelManager
    {
        public List<Travel> travels = new();

        // Används för att skapa trips
        public Travel AddTravel(string destination, int travellers, Countries country, TripeTypes tripType)
        {
            Trip trip = new(destination, country, travellers, tripType);

            travels.Add(trip);

            return trip;
        }

        public List<Travel> GetAllTravels()
        {
            return travels;
        }
        // Används för att skapa vacations
        public Travel AddTravel(string destination, int travellers, Countries country, bool allInclusive)
        {
            Vacation vacation = new(destination, country, travellers, allInclusive);

            travels.Add(vacation);

            return vacation;
        }

        public void RemoveTravel(Travel travelToRemove)
        {
            try
            {
                Travel foundTravel = null;
                foreach (Travel travel in travels)
                {
                    if (travel.Country == travelToRemove.Country && travel.Destination == travelToRemove.Destination && travel.Travelers == travelToRemove.Travelers)
                    {
                        foundTravel = travel;
                    }
                }
                if (foundTravel != null)
                {
                    travels.Remove(foundTravel);
                }
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Please choose a travel first", "Warning");
            }
        }
    }
}
