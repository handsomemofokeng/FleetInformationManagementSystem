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
    /// Interaction logic for windowIncidentInfo.xaml
    /// </summary>
    public partial class windowIncidentInfo : Window
    {
       DBClass dbProcessor;
        List<Driver> driverList;
        List<Truck> truckList;
        public windowIncidentInfo()
        {
            InitializeComponent();
            GetTruckList();
            GetDriverList();
        }

        private void GetDriverList()
        {
            dbProcessor = new DBClass();
            driverList = dbProcessor.DriverList("SELECT * FROM BTC_Drivers");
            cboDriver.Items.Clear();
            foreach (Driver driver in driverList)
            {
                cboDriver.Items.Add(driver);
            }

        }

        private void GetTruckList()
        {
            dbProcessor = new DBClass();
            truckList = dbProcessor.TruckList("SELECT * FROM BTC_Trucks");
            cboTruck.Items.Clear();
            foreach (Truck truck in truckList)
            {
                cboTruck.Items.Add(truck);
            }
        }


        private void btnIncident_Click(object sender, RoutedEventArgs e)
        {
            BLClass blcProcessor = new BLClass();

            string driver = ((Driver)cboDriver.SelectedItem).ToString();
            string truck = ((Truck)cboTruck.SelectedItem).ToString();
            string location = txtLocation.Text;
            string description = txtDescription.Text;
            
            try
            {

                int numberCreated = blcProcessor.ReportIncident(driver, truck, location, description, Convert.ToDateTime(dtIncidentDate.Text));

                if (numberCreated == 1)
                {
                    MessageBox.Show("Incident for:" + truck + " " + driver + "' was successfully added to the database");
                    txtLocation.Clear();
                    txtDescription.Clear();
                }
                else
                {
                    MessageBox.Show("Incident was not sucessfully saved to the database");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
