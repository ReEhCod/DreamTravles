using DreamTravels.Enums;
using DreamTravels.Interfaces;
using DreamTravels.Managers;
using DreamTravels.Models;
using DreamTravles;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        private readonly UserManager userManager;
        private readonly TravelManager travelManager;

        public UserDetailsWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();
            lblUsersNameAndCountry.Content = $"{userManager.SignedInUser.Username} / Location: {userManager.SignedInUser.Location}";
            this.userManager = userManager;
            this.travelManager = travelManager;
            IUser user = userManager.SignedInUser;
            //IUser user = userManager.SignedInUser;
            //lblUsersNameAndCountry.Content = user.Username;

            cbUsersNewCountry.ItemsSource = Enum.GetNames(typeof(Countries));
            cbUsersNewCountry.SelectedItem = cbUsersNewCountry.Items.IndexOf(user.Location);
        }
        // The button saves the inputs and uppdates the user's information
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            var newCountry = cbUsersNewCountry.SelectedItem as string;
            var newUsername = txtNewUsername.Text;
            var newPassword = txtNewPassword.Text;
            if (txtNewUsername.Text.Trim().Length < 0 || txtNewPassword.Text.Trim().Length < 0 || txtConfirmPassword.Text.Trim().Length < 0)
            {
                MessageBox.Show("Please fill all the required fields", "Warning");
            }
            else if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                MessageBox.Show("Password does not match");
            }
            try
            {
                Countries enumCountry = (Countries)Enum.Parse(typeof(Countries), newCountry);
                userManager.AddUser(newUsername, newPassword, enumCountry);
                userManager.UppdateUser(userManager.SignedInUser, txtNewUsername.Text, txtNewPassword.Text, enumCountry);
                TravelsWindow travelsWindow = new(userManager, travelManager);
                travelsWindow.Show();
                Close();

            }
            catch
            {
                MessageBox.Show("Please fill all the required fields", "Warning");
            }
            
            


        }

        // The cancles the process and sends the user to TravelsWindow
        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(userManager, travelManager);
            travelsWindow.Show();
            Close();
        }

    }
}
