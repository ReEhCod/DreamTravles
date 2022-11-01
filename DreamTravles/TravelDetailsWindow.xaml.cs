using DreamTravels.Managers;
using DreamTravels.Models;
using DreamTravles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DreamTravels
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        private readonly UserManager userManager;
        private readonly TravelManager travelManager;
        private readonly List<Travel> travels;

        public TravelDetailsWindow(UserManager userManager, TravelManager travelManager, Travel selectedTravel)
        {
            InitializeComponent();
            this.userManager = userManager;
            this.travelManager = travelManager;
   
            foreach (Travel travel in travels)
            {
                if (travel.Country == selectedTravel.Country)
                {
                    ListViewItem item = new();
                    item.Tag = travel;
                    item.Content = travel.GetInfo();
                    lvTravelDetails.Items.Add(item);
                }
                
            }

            //if (userManager.SignedInUser is Client)
            //{
            //    Client signedInUser = userManager.SignedInUser as Client;

            //    foreach (Travel travel in signedInUser.Travels)
            //    {
            //        ListViewItem item = new();
            //        item.Tag = travel;
            //        item.Content = travel.GetInfo();
            //        lvTravelDetails.Items.Add(item);
            //    }
            //}
            //else if (userManager.SignedInUser is Admin)
            //{
            //    var nonAdminUsers = userManager.GetAllUsers().Where(x => x.IsAdmin != true);

            //    foreach (Client user in nonAdminUsers)
            //    {
            //        foreach (Travel travel in user.Travels)
            //        {
            //            ListViewItem item = new();
            //            item.Tag = travel;
            //            item.Content = travel.GetInfo();
            //            lvTravelDetails.Items.Add(item);
            //        }
            //    }
            //}
        }

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(userManager,travelManager);
            travelsWindow.Show();
            Close();  
        }
    }
}
