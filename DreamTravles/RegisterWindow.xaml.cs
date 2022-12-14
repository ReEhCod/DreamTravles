using DreamTravels.Enums;
using DreamTravels.Interfaces;
using DreamTravels.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace DreamTravles
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private UserManager userManager;
        private TravelManager travelManager;
        public RegisterWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            this.travelManager = travelManager;

            cbCountry.ItemsSource = Enum.GetNames(typeof(Countries));
        }

        // Registers new account for client
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string location = cbCountry.SelectedItem as string;

            try
            {               
                if (txtUsername.Text.Trim().Length < 0 && txtPassword.Text.Trim().Length < 0 && cbCountry.SelectedItem == null)
                {
                    MessageBox.Show("Not all the requierd fields are full", "Warning!");
                    return;
                }
                else if (txtUsername.Text.Trim().Length < 3)
                {
                    MessageBox.Show("Username is too short. It shoud be longer than 3 characters!", "Warning!");
                    return;
                }
                else if (txtPassword.Text.Trim().Length < 5)
                {
                    MessageBox.Show("Password shoud be longer than 5 characters", "Warning!");
                    return;
                }
                else if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
                {
                    MessageBox.Show("Password does not match", "Warning!");
                    return;
                }
                else
                {
                    Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), location);
                    this.userManager.AddUser(username, password, selectedCountry);
                    MainWindow mainWindow = new(this.userManager, travelManager);
                    mainWindow.Show();
                    Close();
                } 
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill all the required fields", "Warning");
                return;
            }
        }

        // Cancels the register and sends back user to main window
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new(userManager, travelManager);
            mainWindow.Show();
            Close();
        }
    }
}
    

