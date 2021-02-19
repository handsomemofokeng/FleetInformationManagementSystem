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
    /// Interaction logic for windowTruckInfo.xaml
    /// </summary>
    public partial class windowTruckInfo : Window
    {
        List<TextBox> textFields;
        List<Truck> truckList;

        Truck selectedTruck;

        public windowTruckInfo()
        {
            InitializeComponent();
            textFields = new List<TextBox>();
            textFields.Add(txtChassisNumber);
            textFields.Add(txtEnginePower);
            textFields.Add(txtFuelTank);
            textFields.Add(txtGVW);
            textFields.Add(txtMake);
            textFields.Add(txtMileage);
            textFields.Add(txtModel);
            textFields.Add(txtPlateNumber);
            textFields.Add(txtTires);
            textFields.Add(txtVehicleNumber);

            DBClass dbProcessor = new DBClass();

            truckList = dbProcessor.TruckList("SELECT * FROM BTC_Trucks");
            lstFindTrucks.Items.Clear();

            foreach (Truck truck in truckList)
            {
                lstFindTrucks.Items.Add(truck);
            }

        }


        private void btnSubmitTruck_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Truck truck = GetTruckDetails();


                BLClass blcProcessor = new BLClass();
                if (blcProcessor.AddNewTruck(truck) == 1)
                {
                    MessageBox.Show(truck + "successfully added to database.", "New Truck Added", MessageBoxButton.OK, MessageBoxImage.Information);
                    new windowTruckInfo().ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error adding " + truck, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private Truck GetTruckDetails()
        {
            Truck truck = new Truck();
            try
            {
                if (MainWindow.IsTextBoxValid(textFields))
                {
                    truck.VinNumber = txtVehicleNumber.Text;
                    truck.ChassisNumber = txtChassisNumber.Text;
                    truck.DateOfPurchase = Convert.ToDateTime(dpDOP.SelectedDate);
                    truck.EnginePower = Convert.ToInt32(txtEnginePower.Text);
                    truck.FuelTankSize = Convert.ToInt32(txtFuelTank.Text);
                    truck.FuelType = cboFuelType.Text;
                    truck.GVW = Convert.ToDouble(txtGVW.Text);
                    truck.LicensePlateNumber = txtPlateNumber.Text;
                    truck.Make = txtMake.Text;
                    truck.Mileage = Convert.ToInt32(txtMileage.Text);
                    truck.Model = txtModel.Text;
                    truck.TireSize = Convert.ToInt32(txtTires.Text);
                    truck.TransmissionType = cboTransmissionType.Text;
                    truck.TruckType = cboTruckType.Text;
                    truck.VinNumber = txtVehicleNumber.Text;
                    truck.Availability = cboAvailability.Text;
                    truck.Steering = cboSteeringType.Text;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return truck;
        }

        private void btnUpdateTruck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Truck updateTruck = GetTruckDetails();
                BLClass blcProcessor = new BLClass();
                if (blcProcessor.UpdateTruck(updateTruck) == 1)
                {
                    MessageBox.Show(updateTruck + "successfully added to database.", "New Truck Added", MessageBoxButton.OK, MessageBoxImage.Information);
                    new windowTruckInfo().ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error adding " + updateTruck, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtNumberPlate_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                
                foreach (Truck t in truckList)
                {
                    lstFindTrucks.Items.Clear();
                    if (t.ToString().Contains(txtFindTruck.Text))
                    {
                        lstFindTrucks.Items.Add(t);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void lstTrucks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                selectedTruck = (Truck)lstFindTrucks.SelectedItem;

                // txtFindNumberPlate.Text = selectedTruck.LicensePlateNumber;
                //if (MessageBox.Show("Show details of Truck " + selectedTruck, "View Truck Info", MessageBoxButton.YesNo,
                //    MessageBoxImage.Question) == MessageBoxResult.Yes)
                //{
                if (selectedTruck != null)
                {
                    txtChassisNumber.Text = selectedTruck.ChassisNumber;
                    txtEnginePower.Text = selectedTruck.EnginePower.ToString();
                    txtFuelTank.Text = selectedTruck.FuelTankSize.ToString();
                    cboFuelType.Text = selectedTruck.FuelType;
                    txtGVW.Text = selectedTruck.GVW.ToString();
                    txtMake.Text = selectedTruck.Make;
                    txtMileage.Text = selectedTruck.Mileage.ToString();
                    txtModel.Text = selectedTruck.Model;
                    txtPlateNumber.Text = selectedTruck.LicensePlateNumber;
                    txtTires.Text = selectedTruck.TireSize.ToString();
                    txtVehicleNumber.Text = selectedTruck.VinNumber;
                    cboAvailability.Text = selectedTruck.Availability;
                    cboFuelType.Text = selectedTruck.FuelType;
                    cboSteeringType.Text = selectedTruck.Steering;
                    cboTransmissionType.Text = selectedTruck.TransmissionType;
                    cboTruckType.Text = selectedTruck.TruckType;

                }


                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            BLClass blcProcessor = new BLClass();

            try
            {
                int numberDeleted = blcProcessor.DeleteTruck(selectedTruck.LicensePlateNumber);

                if (numberDeleted == 1)
                {
                    MessageBox.Show("Truck: '" + selectedTruck + "' was successfully deleted.");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
