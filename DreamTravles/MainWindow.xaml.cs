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
        private TravelManager travelManager;
        public MainWindow()
        {
            InitializeComponent();

            userManager = new();
            travelManager = new();


            // Skapa resor för Gandalf
            AddTravelForGandalf();
        }

        public void AddTravelForGandalf()
        {
            Travel newTrip = travelManager.AddTravel("Ice hotel", 4, Countries.Sweden, TripeTypes.Leisure);
            Travel newVacation = travelManager.AddTravel("Barcelona", 2, Countries.Spain, false);

            for (int i = 0; i < userManager.users.Count; i++)
            {
                if (userManager.users[i].Username == "Gandalf")
                {
                    Client client = userManager.users[i] as Client;

                    client.Travels.Add(newTrip);
                    client.Travels.Add(newVacation);
                }
            }
        }
        public MainWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            this.userManager = userManager;
            this.travelManager = travelManager;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new(userManager, travelManager);
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

                    userManager.SignedInUser = user;

                    TravelsWindow travelsWindow = new(userManager, travelManager);
                    travelsWindow.Show();
                    Close();
                }
                
            }
            
            if (!isFoundUser)
            {
                MessageBox.Show("Username or password is incorrect", "Warning");
            }
            
        }
    }
}
