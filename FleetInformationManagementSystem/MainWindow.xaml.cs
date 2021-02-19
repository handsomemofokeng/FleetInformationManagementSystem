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
using DataAccessLayer;
using BusinessLayer;

namespace FleetInformationManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///     
    public partial class MainWindow : Window
    {
        public static List<User> userList;
        public static List<Driver> driverList;
        public static List<Truck> truckList;
        public static List<Client> clientList;

        public static Driver selctedDriver;

        public static BLClass blcProcessor;
        public static DBClass dbProcessor;
        public static User currentUser;

        /// <summary>
        /// Default Constructor(), initialises MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
            btnLogOut.IsEnabled = false;

            GetUserList();
            GetClientList();
            GetTruckList();
            GetDriverList();
            GetTruckList();
        }

        private void GetUserList()
        {
            dbProcessor = new DBClass();

            userList = dbProcessor.UserList("SELECT * FROM BTC_Users");
            lstUsers.Items.Clear();
            foreach (User user in userList)
            {
                lstUsers.Items.Add(user);
            }
        }

        private void GetClientList()
        {
            dbProcessor = new DBClass();

            clientList = dbProcessor.ClientList("SELECT * FROM BTC_Clients");
            lstClients.Items.Clear();
            foreach (Client client in clientList)
            {
                lstClients.Items.Add(client);
            }
        }

        private void GetDriverList()
        {
            dbProcessor = new DBClass();
            driverList = dbProcessor.DriverList("SELECT * FROM BTC_Drivers");
            lstDrivers.Items.Clear();
            cboRouteDriver.Items.Clear();
            foreach (Driver driver in driverList)
            {
                lstDrivers.Items.Add(driver);
                cboRouteDriver.Items.Add(driver);
            }

        }

        private void GetTruckList()
        {
            dbProcessor = new DBClass();
            truckList = dbProcessor.TruckList("SELECT * FROM BTC_Trucks");
            lstFleet.Items.Clear();
            lstFleet1.Items.Clear();
            foreach (Truck truck in truckList)
            {
                lstFleet1.Items.Add(truck);
                lstFleet.Items.Add(truck);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //myMainWindow.Width = SystemParameters.PrimaryScreenWidth;
            //myMainWindow.Height = SystemParameters.PrimaryScreenHeight;
            //myMainWindow.Top = 0;
            //myMainWindow.Left = 0;
            Initialise();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void mnuExit_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuLogOut_Click(object sender, RoutedEventArgs e)
        {
            Initialise();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuAddDriver_Click(object sender, RoutedEventArgs e)
        {
            wndwDriverInfo newDriver = new wndwDriverInfo();
            newDriver.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            if (IsValidCredentials(txtUsername.Text, pwdPassword.Password))
            {
                grdLogIn.Visibility = Visibility.Collapsed;
                myMenu.IsEnabled = true;
                tabControl.Visibility = Visibility.Visible;
                txtUsername.Clear();
                pwdPassword.Clear();
                txtUsername.Background = Brushes.White;
                pwdPassword.Background = Brushes.White;
                GetUserList();
                GetClientList();
                GetDriverList();
                GetTruckList();

                SetCurrentUser(currentUser);
                btnLogOut.IsEnabled = true;

            }
            else
            {
                //MessageBox.Show("Invalid username or password! Please try again.", "Log In", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUsername.Background = Brushes.Orange;
                pwdPassword.Background = Brushes.Orange;
            }
        }

        private void SetCurrentUser(User  currentUser)
        {

            lblCurrentUser.Visibility = Visibility.Visible;
            imgProfilePicture.Visibility = Visibility.Visible;

            lblCurrentUser.Content = "Logged in as: "+ currentUser.ToString();
            switch (currentUser.Role)
            {
                case "None":
                    tabControl.Visibility = Visibility.Collapsed;
                    break;
                case "Data Capturer":
                    tbAdminMenu.Visibility = Visibility.Collapsed;
                    tbOperatorMenu.Visibility = Visibility.Collapsed;
                    break;
                case "Operator":
                    tbAdminMenu.Visibility = Visibility.Collapsed;
                    tbDataEntryMenu.Visibility = Visibility.Collapsed;
                    break;
                case "Admin":
                    tabControl.Visibility = Visibility.Visible;
                    break;
                default:
                    tabControl.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //if (currentUser.Role == "Admin")
            //{
            new windowRegisterUser().ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("You are not authorized to register a user");
            //    btnRegister.IsEnabled = false;
            //}

        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnGetRoute_Click(object sender, RoutedEventArgs e)
        {
            string startPoint = txtDeparturePoint.Text;
            string endPoint = txtDestination.Text;
            try
            {
                StringBuilder queryAddress = new StringBuilder();
                queryAddress.Append("http://maps.google.co.za/maps/dir/");

                if (startPoint != string.Empty)
                {
                    queryAddress.Append(startPoint + "/");

                }

                if (endPoint != string.Empty)
                {
                    queryAddress.Append(endPoint + "/");
                }

                webRoute.Navigate(queryAddress.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Set window to initial state.
        /// </summary>
        private void Initialise()
        {
            tabControl.Visibility = Visibility.Collapsed;
            myMenu.IsEnabled = false;
            grdLogIn.Visibility = Visibility.Visible;
            lblCurrentUser.Visibility = Visibility.Collapsed;
            imgProfilePicture.Visibility = Visibility.Collapsed;
            txtUsername.Focus();
        }//end method

        private bool IsValidCredentials(string username, string password)
        {
            dbProcessor = new DBClass();
            userList = dbProcessor.UserList("SELECT * FROM BTC_Users");

            bool isValid = false;
            foreach (User user in userList)
            {
                if (username == user.UserEmail.ToString())
                {
                    currentUser = user;
                    isValid = true;
                    break;
                }
            }

            if (isValid)
            {
                isValid = false;
                if (password == currentUser.Password)
                {
                    isValid = true;
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Invalid Credentials",
                        MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
            else
            {
                MessageBox.Show("No user registered as " + username, "User not found.",
                    MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            return isValid;
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            //if (currentUser.Role == "Admin")
            //{
            new windowRegisterUser().ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("You are not authorized to register a user");
            //    btnRegister.IsEnabled = false;
            //}
        }

        private void btnAddDriver_Click(object sender, RoutedEventArgs e)
        {
            wndwDriverInfo newDriver = new wndwDriverInfo();
            newDriver.ShowDialog();
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            new windowClientInfo().ShowDialog();
        }

        private void btnAddTruck_Click(object sender, RoutedEventArgs e)
        {
            new windowTruckInfo().ShowDialog();
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            selctedDriver = (Driver)lstDrivers.SelectedItem;
            MessageBox.Show(selctedDriver.ToString());
        }

        public static bool IsTextBoxValid(List<TextBox> TextBoxes)
        {
            bool isValid = true;
            foreach (TextBox txtBox in TextBoxes)
            {
                if (txtBox.Text == string.Empty)
                {
                    isValid = false;
                    txtBox.Background = Brushes.Orange;
                }
                else
                {
                    txtBox.Background = Brushes.White;
                }
            }
            return isValid;
        }

        private void btnGeneratePayroll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Driver driver = (Driver)cboRouteDriver.SelectedItem;
                Payroll payroll = new Payroll(driver, Convert.ToInt32(txtDistance.Text));
                payroll.DeparturePoint = txtDeparturePoint.Text;
                payroll.DestinationPont = txtDestination.Text;
                payroll.Driver = driver;
                payroll.DriverName = payroll.Driver.ToString();
                payroll.Distance = Convert.ToInt32(txtDistance.Text);
                txtTotalPay.Text = payroll.TotalPay.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSubmitRoute_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string GetNewClientID()
        {
            string clientID = "clnt-";
            char[] clientRef = Guid.NewGuid().ToString().ToUpper().ToCharArray();

            for (int i = 0; i < 8; i++)
            {
                clientID += clientRef[i];
            }
            return clientID;
        }

        private void btnAddIncidentReport_Click(object sender, RoutedEventArgs e)
        {
            new windowIncidentInfo().ShowDialog();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new MainWindow().Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }//end Class
}//end Namespace