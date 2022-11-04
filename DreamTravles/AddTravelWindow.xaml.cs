using DreamTravels.Enums;
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
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DreamTravels
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        private readonly UserManager userManager;
        private readonly TravelManager travelManager;
        private bool isAllInclusive = false;

        public AddTravelWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            this.travelManager = travelManager;
            lblUsersName.Content = $"{userManager.SignedInUser.Username}";

            string[] country = Enum.GetNames(typeof(Countries));
            cbCountry.ItemsSource = country;
            string[] typeOfTravel = Enum.GetNames(typeof(TripOrVacation));
            cbTypeOfTravel.ItemsSource = typeOfTravel;
            string[] tripType = Enum.GetNames(typeof(TripeTypes));
            cbTripType.ItemsSource = tripType;

        }

        // Adds new travel for the client 
        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            string country = cbCountry.SelectedItem as string;
            string destination = txtDestination.Text;
            string travelers = txtTravelers.Text;
            string typeOfTravel = cbTypeOfTravel.SelectedItem as string;

            try
            {
                Countries enumCountry = (Countries)Enum.Parse(typeof(Countries), country);
                int intTravelers = int.Parse(travelers);
                
                if(cbTypeOfTravel.SelectedItem == null)
                {
                    MessageBox.Show("Please fill all the required fields", "Warning!");
                    return;
                }
                if (typeOfTravel == "Trip")
                {
                    if (cbCountry.SelectedItem == null || cbTripType.SelectedItem == null || txtDestination.Text == null || txtTravelers.Text == null)
                    {
                        MessageBox.Show("Please fill all the required fields", "Warning!");
                        return;
                    }
                    string tripType = cbTripType.SelectedItem as string;
                    TripeTypes enumTripType = (TripeTypes)Enum.Parse(typeof(TripeTypes), tripType);

                    Travel newTravel = travelManager.AddTravel(destination, intTravelers, enumCountry, enumTripType);

                    Client signedInClient = userManager.SignedInUser as Client;
                    signedInClient.Travels.Add(newTravel);
                }
                else if(typeOfTravel == "Vacation")
                {
                    if (cbCountry.SelectedItem == null || txtDestination.Text == null || txtTravelers.Text == null)
                    {
                        MessageBox.Show("Please fill all the required fields", "Warning!");
                        return;
                    }
                    isAllInclusive = (bool)ckbAllInclusive.IsChecked;

                    Travel newTravel = travelManager.AddTravel(destination, intTravelers, enumCountry, isAllInclusive);

                    Client signedInClient = userManager.SignedInUser as Client;
                    signedInClient.Travels.Add(newTravel);
                }

                TravelsWindow travelsWindow = new(userManager, travelManager);
                travelsWindow.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // Changes the selection depending on if it's trip or vaccation
        private void cbTypeOfTravel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = cbTypeOfTravel.SelectedItem as string;
            switch (selectedItem)
            {
                case "Trip":
                    {
                        cbTripType.Visibility = Visibility.Visible;
                        lblTripType.Visibility = Visibility.Visible;

                        ckbAllInclusive.Visibility = Visibility.Hidden;
                        break;
                    }
                case "Vacation":
                    {
                        ckbAllInclusive.Visibility = Visibility.Visible;

                        cbTripType.Visibility = Visibility.Hidden;
                        lblTripType.Visibility = Visibility.Hidden;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        // Let the user leave the page and go back to travelsWindow
        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(userManager, travelManager);
            travelsWindow.Show();
            Close();
        }
    }
}
