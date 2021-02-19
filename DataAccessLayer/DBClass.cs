using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Configuration;

namespace DataAccessLayer
{
    public class DBClass
    {
        string connectionString = string.Empty;

        public DBClass()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Name"].ConnectionString;
        }
        
        public int ExecuteSQLStatement(string sqlStatement)
        {
            int rowsAffected = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // The insertSQL string contains a SQL statement that
                // inserts a new row in the source table.
                OleDbCommand command = new OleDbCommand(sqlStatement);

                // Set the Connection to the new OleDbConnection.
                command.Connection = connection;

                // Open the connection and execute the insert command.
                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }
            return rowsAffected;
        }

        public List<Client> ClientList(string queryString)
        {
            List<Client> results = new List<Client>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Client clientRecord = new Client();
                    clientRecord.ClientID = reader["ClientID"].ToString();
                    clientRecord.CompanyName = reader["CompanyName"].ToString();

                    Person cp1 = new Person();
                    cp1.Name = reader["ContactName1"].ToString();
                    cp1.Surname = reader["ContactSurame1"].ToString();
                    cp1.Phone = reader["ContactPhone1"].ToString();
                    cp1.Email = reader["ContactEmail1"].ToString();
                    clientRecord.ContactPerson1 = cp1;

                    Person cp2 = new Person();
                    cp1.Name = reader["ContactName2"].ToString();
                    cp1.Surname = reader["ContactSurame2"].ToString();
                    cp1.Phone = reader["ContactPhone2"].ToString();
                    cp1.Email = reader["ContactEmail2"].ToString();
                    clientRecord.ContactPerson1 = cp2;

                    clientRecord.RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"].ToString());

                    Address adr1 = new Address();
                    adr1.StreetAddress = reader["StreetAddress1"].ToString();
                    adr1.City = reader["City1"].ToString();
                    adr1.Province = reader["Province1"].ToString();
                    adr1.ZipCode = Convert.ToInt32( reader["ZipCode1"].ToString());
                    clientRecord.ClientAddress1 = adr1;

                    Address adr2 = new Address();
                    adr2.StreetAddress = reader["StreetAddress2"].ToString();
                    adr2.City = reader["City2"].ToString();
                    adr2.Province = reader["Province2"].ToString();
                    adr2.ZipCode = Convert.ToInt32(reader["ZipCode2"].ToString());
                    clientRecord.ClientAddress1 = adr2;

                    //clientRecord.ContactFullName = reader["ContactFullName"].ToString();
                    //clientRecord.ContactPhone = reader["ContactPhone"].ToString();
                    //clientRecord.ContactEmail = reader["ContactEmail"].ToString();
                    //clientRecord.RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"]);

                    //Address ca = new Address();
                    //ca.AddressLine1 = reader["AddressLine1"].ToString();
                    //ca.City = reader["City"].ToString();
                    //ca.Province = reader["Province"].ToString();
                    //ca.ZipCode = Convert.ToInt32(reader["ZipCode"].ToString());

                    //clientRecord.ClientAddress1 = ca;

                    //clientRecord.ClientAddress.AddressLine1 = reader["AddressLine1"].ToString();
                    //clientRecord.ClientAddress.City = reader["City"].ToString();
                    //clientRecord.ClientAddress.Province = reader["Province"].ToString();
                    //clientRecord.ClientAddress.ZipCode = Convert.ToInt32(reader["ZipCode"].ToString());


                    results.Add(clientRecord);
                }
                reader.Close();
            }
            return results;
        }

        public List<Truck> TruckList(string queryString)
        {
            List<Truck> results = new List<Truck>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Truck truckRecord = new Truck();
                    truckRecord.VinNumber = reader["VinNumber"].ToString();
                    truckRecord.LicensePlateNumber = reader["LicensePlateNumber"].ToString();
                    truckRecord.TruckType = reader["TruckType"].ToString();
                    truckRecord.TransmissionType = reader["TransmissionType"].ToString();
                    truckRecord.FuelType = reader["FuelType"].ToString();
                    truckRecord.ChassisNumber = reader["ChassisNumber"].ToString();
                    truckRecord.Make = reader["Make"].ToString();
                    truckRecord.Model = reader["Model"].ToString();

                    truckRecord.Mileage = Convert.ToInt32(reader["Mileage"]);
                    truckRecord.TireSize = Convert.ToInt32(reader["TireSize"]);

                    truckRecord.DateOfPurchase = Convert.ToDateTime(reader["DateOfPurchase"]);
                    truckRecord.FuelTankSize = Convert.ToInt32(reader["FuelTankSize"]);
                    truckRecord.EnginePower = Convert.ToInt32(reader["EnginePower"]);
                    truckRecord.GVW = Convert.ToDouble(reader["GVW"]);
                    truckRecord.Steering = reader["Steering"].ToString();
                    truckRecord.Availability = reader["Availability"].ToString();

                    results.Add(truckRecord);
                }
                reader.Close();
            }
            return results;
        }

        public List<Payroll> PayrollList(string queryString)
        {
            List<Payroll> results = new List<Payroll>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //Payroll payrollRecord = new Payroll();

                    //payrollRecord.PayrollID = reader["PayrollID"].ToString();
                    //payrollRecord.DriverID = reader["DriverID"].ToString();
                    //payrollRecord.TruckType = reader["TruckType"].ToString();
                    //payrollRecord.TransmissionType = reader["TransmissionType"].ToString();
                    //payrollRecord.FuelType = reader["FuelType"].ToString();
                    //payrollRecord.ChassisNumber = reader["ChassisNumber"].ToString();
                    //payrollRecord.Make = reader["Make"].ToString();
                    //payrollRecord.Model = reader["Model"].ToString();
                    //payrollRecord.GVW = Convert.ToInt32(reader["GVW"].ToString());
                    //payrollRecord.FuelTankSize = Convert.ToInt32(reader["FuelTankSize"].ToString());
                    //payrollRecord.EnginePower = Convert.ToInt32(reader["EnginePower"].ToString());
                    //payrollRecord.Mileage = Convert.ToInt32(reader["Mileage"].ToString());
                    //payrollRecord.TireSize = Convert.ToInt32(reader["TireSize"].ToString());
                    //payrollRecord.DateOfPurchase = Convert.ToDateTime(reader["DateOfPurchase"].ToString());

                   // results.Add(payrollRecord);
                }
                reader.Close();
            }
            return results;
        }

        public List<User> UserList(string queryString)
        {
            List<User> results = new List<User>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User userRecord = new User();
                    userRecord.UserEmail = reader["Email"].ToString();
                    userRecord.Role = reader["Role"].ToString();
                    userRecord.Password = reader["Password"].ToString();
                    userRecord.Name = reader["Name"].ToString();
                    userRecord.Surname = reader["Surname"].ToString();
                    results.Add(userRecord);

                }
                reader.Close();
            }
            return results;
        }

        public List<Driver> DriverList(string queryString)
        {
            List<Driver> results = new List<Driver>();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Driver driverRecord = new Driver();
                    driverRecord.ID = reader["DriverID"].ToString();
                    driverRecord.Name = reader["DriverName"].ToString();
                    driverRecord.Surname = reader["DriverSurname"].ToString();
                    driverRecord.Phone = reader["DriverPhone"].ToString();
                    driverRecord.Email = reader["DriverEmail"].ToString();
                    driverRecord.PostalAddress = reader["DriverPostalAddress"].ToString();

                    License DL = new License(Convert.ToInt32(reader["DriverOldLicenseCode"]),
                        reader["DriverNewLicenseCode"].ToString(), 
                        Convert.ToDateTime(reader["DriverLicenceDOI"]),
                        Convert.ToDateTime(reader["DriverLicenseDOE"]));
                    driverRecord.DriverLicense = DL;

                    Address DriverAddress = new Address();
                    DriverAddress.StreetAddress = reader["DriverStreetAddress"].ToString();
                    DriverAddress.City = reader["DriverCity"].ToString();
                    DriverAddress.Province = reader["DriverProvince"].ToString();
                    DriverAddress.ZipCode = Convert.ToInt32(reader["DriverZipCode"]);

                    driverRecord.PersonAddress = DriverAddress;

                    driverRecord.Availability = reader["Availability"].ToString();
                    driverRecord.PayrollFactor = Convert.ToDouble(reader["DriverPayrollFactor"]);
                    driverRecord.Initial = Convert.ToChar(reader["DriverInitial"]);

                    
                    Person EC = new Person();
                    EC.Name = reader["EmergencyContactName"].ToString();
                    EC.Surname = reader["EmergencyContactSurname"].ToString();
                    EC.Phone = reader["EmergencyContactPhone"].ToString();
                    EC.Email = reader["EmergencyContactEmail"].ToString();

                    Address ECAddress = new Address();
                    ECAddress.StreetAddress = reader["EmergencyContactStreetAddress"].ToString();
                    ECAddress.City = reader["EmergencyContactCity"].ToString();
                    ECAddress.Province = reader["EmergencyContactProvince"].ToString();
                    ECAddress.ZipCode = Convert.ToInt32(reader["EmergencyContactZipCode"]);
                    EC.PersonAddress = ECAddress;
                                      
                    results.Add(driverRecord);
                }
                reader.Close();
            }
            return results;
        }

    }
}