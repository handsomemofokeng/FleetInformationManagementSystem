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
using BusinessLayer;
using DataAccessLayer;


namespace FleetInformationManagementSystem
{
    /// <summary>
    /// Interaction logic for windowRegisterUser.xaml
    /// </summary>
    public partial class windowRegisterUser : Window
    {
        public windowRegisterUser()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtFirstName.Text != string.Empty && txtLastName.Text != string.Empty && txtEmail.Text != string.Empty
                    && txtPassword.Password != string.Empty && txtConfirm.Password != string.Empty)
                {

                    if (txtEmail.Text.EndsWith("@btc.com"))
                    {
                        if (txtPassword.Password == txtPassword.Password)
                        {

                            User user = new User();

                            user.Name = txtFirstName.Text;
                            user.Surname = txtLastName.Text;
                            user.Role = cboRole.Text;
                            user.Password = txtConfirm.Password;
                            user.UserEmail = txtEmail.Text;
                            BLClass blcProcessor = new BLClass();
                            

                            if (blcProcessor.AddNewUser(user) == 1)
                            {
                                MessageBox.Show("User registered successfully.", "User Registered",
                                    MessageBoxButton.OK, MessageBoxImage.Information);
                                new windowRegisterUser().Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("User registration failed.", "User Not Registered",
                                   MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please make sure passwords match!", "Passwords mismatch.",
                           MessageBoxButton.OK, MessageBoxImage.Warning);
                        }


                    }
                    else
                    {
                        MessageBox.Show("User must register with BTC email address.", "Invalid Email.",
                       MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Please enter all fields!", "Inomplete Form.",
                       MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

        }

        private void btnProfilePicture_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}