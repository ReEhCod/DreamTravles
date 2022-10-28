using DreamTravels.Enums;
using DreamTravels.Interfaces;
using DreamTravels.Managers;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DreamTravles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager userManager;
        public MainWindow()
        {
            InitializeComponent();

            userManager = new();
        }
        public MainWindow(UserManager userManager)
        {
            InitializeComponent();

            this.userManager = userManager;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new(userManager);
            registerWindow.Show();
            Close();

        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {

            List<IUser> users = userManager.GetAllUsers();
            string usernam = txtUsername.Text;
            string password = pswPassword.Password;
            bool isFoundUser = false;
            foreach (IUser user in users)
            {
                if(user.Username == usernam && user.Password == password)
                {
                    isFoundUser = true;
                    TravelsWindow travelsWindow = new(userManager, user);
                    travelsWindow.Show();
                }
            }
            if (!isFoundUser)
            {
                MessageBox.Show("Username or password is incorrect", "Warning");
            }
            Close();
        }
    }
}
