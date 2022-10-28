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
        private UserManager userManager = new();
        public RegisterWindow(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;

            cbCountry.ItemsSource = Enum.GetValues(typeof(Countries));


        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string location = cbCountry.SelectedItem.ToString();
            Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), location);

            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                MessageBox.Show("Passwords does not match", "Warning!");
            }
            else if(txtPassword.Text.Trim().Length < 5)
            {
                MessageBox.Show("Password shoud be longer than 5 characters", "Warning!");
            }
            else if (txtUsername.Text.Trim().Length < 3)
            {
                MessageBox.Show("Username is too short. It shoud be longer than 3 characters!", "Warning!");
            }
            else if (txtUsername.Text.Trim().Length < 0 && txtPassword.Text.Trim().Length < 0 && string.IsNullOrEmpty(cbCountry.Text))
            {
                MessageBox.Show("Not all the requierd fields are full", "Warning!");
            }
            else if (this.userManager.AddUser(username, password, selectedCountry))
            {
                // Användare har skapats
                MainWindow mainWindow = new(this.userManager);
                mainWindow.Show();
                Close();

            }
            
        }
    }
}
