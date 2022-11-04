using DreamTravels;
using DreamTravels.Enums;
using DreamTravels.Interfaces;
using DreamTravels.Managers;
using DreamTravels.Models;
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

namespace DreamTravles
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        private Admin admin;
        private Client client;
        private Travel newTravel;
        private UserManager userManager;
        private TravelManager travelManager;
        private List<Travel> travels;
            
        public TravelsWindow(UserManager userManager, TravelManager travelManager)
        {

            InitializeComponent();
            lblUsersName.Content = $"{userManager.SignedInUser.Username}";
            
            this.userManager = userManager;
            this.travelManager = travelManager;
            TravelInfo();

            if (userManager.SignedInUser is Admin)
            {
                btnAddTravel.Visibility = Visibility.Hidden;
                btnUser.Visibility = Visibility.Hidden;
                btnInfo.Visibility = Visibility.Hidden;
            }
        }

        // Sends all nececcary information about a travel to the listview
        private void TravelInfo()
        {
            lvTravels.Items.Clear();


            if (userManager.SignedInUser is Client)
            {
                Client signedInUser = userManager.SignedInUser as Client;

                foreach (Travel travel in signedInUser.Travels)
                {
                    ListViewItem item = new();
                    item.Tag = travel;
                    item.Content = travel.Country;
                    lvTravels.Items.Add(item);
                }
            }
            else if (userManager.SignedInUser is Admin)
            {
                foreach (Travel travel in travelManager.travels)
                {
                    ListViewItem item = new();
                    item.Tag = travel;
                    item.Content = travel.Country;
                    lvTravels.Items.Add(item);
                }
            }
        }

        // Opens the AddTravelWindow
        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {

                
                    AddTravelWindow addTravelWindow = new(userManager, travelManager);
                    addTravelWindow.Show();
                    Close();
        }

        // Button to remove selected travel form the list
        private void btnRemoveTravel_Click(object sender, RoutedEventArgs e)
        {
            // Check if any travel is selected
            if (lvTravels.SelectedItem == null)
            {
                // If not, show a massage
                MessageBox.Show("Please choose a travel first");
            }
            else
            {
                // If selected remove the travel
                ListViewItem selectedItem = lvTravels.SelectedItem as ListViewItem;
                Travel selectedTravel = selectedItem.Tag as Travel;

                travelManager.RemoveTravel(selectedTravel);

                foreach(IUser user in userManager.GetAllUsers())
                {
                    if(user is Client)
                    {
                        Client client = user as Client;

                        if(client.Travels.Contains(selectedTravel))
                        {
                            client.Travels.Remove(selectedTravel);
                        }
                    }
                }

                // Uppdate UI after removing the travel
                TravelInfo();
            }
        }

        // Open the TravelDetailsWindow after choosing a travel from the list 
        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = lvTravels.SelectedItem as ListViewItem;

            if (selectedItem == null)
            {
                MessageBox.Show("Please choose a travel first");
            }
            else
            {
                Travel selectedTravel = selectedItem.Tag as Travel; 

                TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow(userManager, travelManager, selectedTravel);
                travelDetailsWindow.Show();
                Close();
            }
        }

        // Sign out the user from the account and MainWindow pops up
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new(userManager, travelManager);
            mainWindow.Show();
            Close();
        }

        // Send user to UserDetailsWindow
        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userDetailsWindow = new(userManager, travelManager);
            userDetailsWindow.Show();
            Close();
        }

        // After clicked a massage box pops up and shows information about the company and how to use the app
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi and welcome to Dream Travels! Dream Travel is established in 2022 in Sweden.Our vision is to give you your dream travels and the best experience.\nYou can choose between our many countries and destinations to travel to.\nIf you need help you can hold your mouse on each button to know what it does.");
        }

    }
}
