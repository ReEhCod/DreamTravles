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

        public TravelDetailsWindow(UserManager userManager, TravelManager travelManager, Travel selectedTravel)
        {
            InitializeComponent();
            this.userManager = userManager;
            this.travelManager = travelManager;

            lvTravelDetails.Items.Add(selectedTravel.GetInfo());
        }

        // Cancle the process and send user back to TravelsWindow
        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(userManager,travelManager);
            travelsWindow.Show();
            Close();  
        }
    }
}
