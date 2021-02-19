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
using DataAccessLayer;
using BusinessLayer;
namespace FleetInformationManagementSystem
{
    /// <summary>
    /// Interaction logic for wndwDriverInfo.xaml
    /// </summary>
    public partial class wndwDriverInfo : Window
    {

        List<TextBox> textFields;
        Driver driver;
        License license;
        Person emergencyContact;
        List<Driver> driverList;

        public wndwDriverInfo()
        {
            InitializeComponent();

            textFields = new List<TextBox>();
            textFields.Add(txtCity);
            textFields.Add(txtStreetAddress);
            textFields.Add(txtDriverEmailAddress);
            textFields.Add(txtDriverInitial);
            textFields.Add(txtDriverName);
            textFields.Add(txtDriverNickName);
            textFields.Add(txtDriverPhoneNumber);
            textFields.Add(txtDriverPostalAddress);
            textFields.Add(txtDriverSurname);
            textFields.Add(txtEmergencyEmailAddress);
            textFields.Add(txtEmergencyName);
            textFields.Add(txtEmergencyPhoneNumber);
            textFields.Add(txtEmergencySurname);
            txtPayrollFactor.Text = "2";

            DBClass dbProcessor = new DBClass();
            driverList = dbProcessor.DriverList("SELECT * FROM BTC_Drivers");
        
        }

        private void windowDriverInfo_Loaded(object sender, RoutedEventArgs e)
        {
            txtPayrollFactor.Text = "2";
            prgbarProgess.Value = 33.4;

            if (lstFindDrivers != null)
            {
                lstFindDrivers.Items.Clear();
                foreach (Driver dvr in driverList)
                {
                    lstFindDrivers.Items.Add(dvr);
                }
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                textFields = new List<TextBox>();
                textFields.Add(txtCity);
                textFields.Add(txtStreetAddress);
                textFields.Add(txtDriverEmailAddress);
                textFields.Add(txtDriverInitial);
                textFields.Add(txtDriverName);
                textFields.Add(txtDriverPhoneNumber);
                textFields.Add(txtDriverPostalAddress); 
                textFields.Add(txtDriverSurname);
                textFields.Add(txtZipCode);

                if (MainWindow.IsTextBoxValid(textFields))
                {
                    driver = new Driver();
                    driver.Email = txtDriverEmailAddress.Text;
                    driver.ID = txtDriverID.Text;
                    driver.Name = txtDriverName.Text;
                    driver.Initial = char.Parse(txtDriverInitial.Text);
                    driver.Surname = txtDriverSurname.Text;
                    driver.Nickname = txtDriverNickName.Text;
                    driver.PostalAddress = txtDriverPostalAddress.Text;
                    driver.Phone = txtDriverPhoneNumber.Text;

                    Address driverAddress = new Address();
                    driverAddress.City = txtCity.Text;
                    driverAddress.StreetAddress = txtStreetAddress.Text;
                    driverAddress.Province = cboProvince.Text;
                    driverAddress.ZipCode = Convert.ToInt32(txtZipCode.Text);
                    if(driverAddress != null)
                         driver.PersonAddress = driverAddress;

                    tabControl.SelectedIndex++;
                }
                else
                {
                    MessageBox.Show("Please fill in the values highlighted in orange.", "Missing required details", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "wndwDriverInfo: btnNext_Click");
            }
        }//end method

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tabControl.SelectedIndex--;
                //prgbarProgess.Value -= 66.8;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "wndwPrevious: btnNext_Click");
            }

        }//end method

        private void btnSumitDriver_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (MainWindow.IsTextBoxValid(textFields))
                {
                    if (driver != null)
                    {
                        if (emergencyContact != null)
                        {
                            driver.PayrollFactor = Convert.ToDouble(txtPayrollFactor.Text);
                            license = new License(Convert.ToInt32(cboOldLicenseCode.Text), cboNewLicenseCode.Text,
                              Convert.ToDateTime(dpLicenseDOI.SelectedDate), Convert.ToDateTime(dpLicenseDOE.SelectedDate));

                            driver.DriverLicense = license;
                            driver.Availability = cboAvailability.Text;
                           
                            BLClass blcProcessor = new BLClass();

                            if (blcProcessor.AddNewDriver(driver) == 1)
                            {
                                MessageBox.Show(driver + " saved and submitted successfully", "Driver Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                                new wndwDriverInfo().Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show(driver +" successfully saved to database.", "Driver saved", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please save Emergency Contact details before submitting", "Missing details", MessageBoxButton.OK, MessageBoxImage.Warning);
                            tabControl.SelectedIndex = 1;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please save Driver details before submitting", "Missing details", MessageBoxButton.OK, MessageBoxImage.Warning);
                        tabControl.SelectedIndex = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in fields highlighted in orange", "Some Details Missing", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    tabControl.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnGenerateDriverID_Click(object sender, RoutedEventArgs e)
        {
            //textFields = new List<TextBox>();
            //textFields.Add(txtCity);
            //textFields.Add(txtStreetAddress);
            //textFields.Add(txtDriverEmailAddress);
            //textFields.Add(txtDriverInitial);
            //textFields.Add(txtDriverName);
            //textFields.Add(txtDriverNickName);
            //textFields.Add(txtDriverPhoneNumber);
            //textFields.Add(txtDriverPostalAddress);
            //textFields.Add(txtDriverSurname);
            //textFields.Add(txtEmergencyEmailAddress);
            //textFields.Add(txtEmergencyName);
            //textFields.Add(txtEmergencyPhoneNumber);
            //textFields.Add(txtEmergencySurname);
            //ClearAllFields(textFields);

            driver = null;
            license = null;
            emergencyContact = null;
            string driverID = "dvr-";
            string guid = Guid.NewGuid().ToString().ToUpper();
            char[] id = guid.ToCharArray();
            for (int i = 0; i < 8; i++)
            {
                driverID += id[i];
            }

            txtDriverID.Text = driverID;

        }

        private void ClearAllFields(List<TextBox> textFields)
        {
            foreach (TextBox tbx in textFields)
            {
                tbx.Text = "";
            }
        }

        private double GetPayrollFactor(int licenseCode)
        {
            return 2 + (0.25 * (licenseCode - 1));
        }

        private void cboOldLicenseCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

            if (txtPayrollFactor != null)
            { int cde = cboOldLicenseCode.SelectedIndex;
            double pf = GetPayrollFactor(cde);
                txtPayrollFactor.Text = Convert.ToString(pf);
            }
            
        }

        private void btnSaveEC_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (driver != null)
                {
                    textFields = new List<TextBox>();
                    textFields.Add(txtEmergencyEmailAddress);
                    textFields.Add(txtEmergencyName);
                    textFields.Add(txtEmergencyPhoneNumber);
                    textFields.Add(txtEmergencySurname);
                    textFields.Add(txtECCity);
                    textFields.Add(txtECStreetAddress);
                    textFields.Add(txtECZipCode);

                    if (MainWindow.IsTextBoxValid(textFields))
                    {
                        emergencyContact = new Person();
                        emergencyContact.Name = txtEmergencyName.Text;
                        emergencyContact.Surname = txtEmergencySurname.Text;
                        emergencyContact.Phone = txtEmergencyPhoneNumber.Text;
                        emergencyContact.Email = txtEmergencyEmailAddress.Text;
                        emergencyContact.Relationship = cboRelationship.Text;

                        Address ECAddress = new Address();
                        ECAddress.StreetAddress = txtECStreetAddress.Text;
                        ECAddress.City = txtECCity.Text;
                        ECAddress.Province = cboECProvince.Text;
                        ECAddress.ZipCode = Convert.ToInt32(txtECZipCode.Text);

                        if (ECAddress != null)
                        {
                            emergencyContact.PersonAddress = ECAddress;
                        }
                        driver.EmergencyContact = emergencyContact;

                        tabControl.SelectedIndex++;
                    }
                    else
                    {
                        MessageBox.Show("Please provide details highlighted in orange", "Missing details", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Please save driver details before you can proceed", "Save to continue", MessageBoxButton.OK, MessageBoxImage.Information);
                    tabControl.SelectedIndex = 0;
                    // prgbarProgess.Value = 33.4;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void txtFindDriver_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstFindDrivers.Items.Clear();
            foreach (Driver dvr in driverList)
            {
                if (dvr.ToString().ToUpper().Contains(txtFindDriver.Text.ToUpper()))
                {
                    lstFindDrivers.Items.Add(dvr);
                }

            }
        }
    }//end class
}//end namespace
