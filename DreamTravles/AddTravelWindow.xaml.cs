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

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            string country = cbCountry.SelectedItem as string;
            

            string destination = txtDestination.Text;
            string travelers = txtTravelers.Text;
            string typeOfTravel = cbTypeOfTravel.SelectedItem as string;


            if (cbCountry.SelectedItem == null || cbTypeOfTravel.SelectedItem == null || cbTripType.SelectedItem == null || ckbAllInclusive.IsChecked == null || txtDestination.Text == null || txtTravelers.Text == null)
            {
                MessageBox.Show("Please fill all the required fields", "Warning!");
                return;
            }

            try
            {
                Countries enumCountry = (Countries)Enum.Parse(typeof(Countries), country);
                int intTravelers = int.Parse(travelers);

                if (typeOfTravel == "Trip")
                {
                    string tripType = cbTripType.SelectedItem as string;
                    TripeTypes enumTripType = (TripeTypes)Enum.Parse(typeof(TripeTypes), tripType);

                    Travel newTravel = travelManager.AddTravel(destination, intTravelers, enumCountry, enumTripType);

                    Client signedInClient = userManager.SignedInUser as Client;
                    signedInClient.Travels.Add(newTravel);
                }
                else if(typeOfTravel == "Vacation")
                {
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
    }
}
