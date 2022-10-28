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
            
            if(this.userManager.AddUser(username,password,selectedCountry))
            {
                // Användare har skapats

                Close();
            }
            else
            {
                MessageBox.Show("The username was invalid or already taken!");
            }
        }
    }
}
