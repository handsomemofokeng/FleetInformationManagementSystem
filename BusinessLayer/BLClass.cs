using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BLClass
    {
        public BLClass() { }



        //public int AddNewTruck(Truck NewTruck)
        //{
        //    int insertedRows = -1;
        //    DBClass dataAccess = new DBClass();
        //    try
        //    {
        //        StringBuilder sqlStmnt = new StringBuilder();
        //        sqlStmnt = new StringBuilder();
        //        sqlStmnt.Append("INSERT INTO BTC_Trucks (VinNumber, LicensePlateNumber," +
        //            "TransmissionType, FuelType, ChassisNumber, Make, Model, GVW, FuelTankSize" +
        //            "EnginePower, Mileage, TireSize, DateOfPurchase, TruckType) VALUES ('");
        //        sqlStmnt.Append(NewTruck.VinNumber);
        //        sqlStmnt.Append("','");
        //        sqlStmnt.Append(NewTruck.LicensePlateNumber);
        //        sqlStmnt.Append("','");
        //        sqlStmnt.Append(NewTruck.TransmissionType);
        //        sqlStmnt.Append("','");
        //        sqlStmnt.Append(NewTruck.FuelType);
        //        sqlStmnt.Append("','");
        //        sqlStmnt.Append(NewTruck.ChassisNumber);
        //        sqlStmnt.Append("','");
        //        sqlStmnt.Append(NewTruck.Make);
        //        sqlStmnt.Append("','");
        //        sqlStmnt.Append(NewTruck.Model);
        //        sqlStmnt.Append("','");
        //        sqlStmnt.Append(NewTruck.GVW);
        //        sqlStmnt.Append("','");
        //        sqlStmnt.Append(NewTruck.FuelTankSize);
        //        sqlStmnt.Append("','");
        //        sqlStmnt.Append(NewTruck.EnginePower);
        //        sqlStmnt.Append("','");
        //        sqlStmnt.Append(NewTruck.Mileage);
        //        sqlStmnt.Append("','");
        //        sqlStmnt.Append(NewTruck.TireSize);
        //        sqlStmnt.Append("','");
        //        sqlStmnt.Append(NewTruck.DateOfPurchase.ToShortDateString());
        //        sqlStmnt.Append("','");
        //        sqlStmnt.Append(NewTruck.TruckType);
        //        sqlStmnt.Append("');");

        //        insertedRows = dataAccess.ExecuteSQLStatement(sqlStmnt.ToString());

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    return insertedRows;
        //}

        public int AddNewUser(User NewUser)
        {
            int insertedRows = -1;
            DBClass dataAccess = new DBClass();

            try
            {
                StringBuilder sqlStmnt = new StringBuilder();
                sqlStmnt.Append("INSERT INTO BTC_Users (Email, Name, Surname, Role, Password) VALUES ('");
                sqlStmnt.Append(NewUser.UserEmail);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewUser.Name);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewUser.Surname);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewUser.Role);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewUser.Password);
                sqlStmnt.Append("');");

                insertedRows = dataAccess.ExecuteSQLStatement(sqlStmnt.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return insertedRows;
        }

        public int AddNewDriver(Driver NewDriver)
        {
            int insertedRows = -1;
            DBClass dataAccess = new DBClass();

            try
            {
                StringBuilder sqlStmnt = new StringBuilder();
                sqlStmnt.Append("INSERT INTO BTC_Drivers (DriverID, DriverName, DriverSurname," +
                    "DriverPhone, DriverEmail, DriverOldLicenseCode, DriverNewLicenseCode, DriverLicenceDOI, " +
                    "DriverLicenseDOE, EmergencyContactName, EmergencyContactSurname, EmergencyContactPhone, EmergencyContactEmail, " +
                    "EmergencyContactStreetAddress, EmergencyContactCity, EmergencyContactProvince, EmergencyContactZipCode, " +
                    "DriverStreetAddress, DriverCity,  DriverProvince,DriverZipCode, DriverPostalAddress, Availability, " +
                    "DriverPayrollFactor, DriverInitial) VALUES('");
                sqlStmnt.Append(NewDriver.ID);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.Name);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.Surname);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.Phone);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.Email);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.DriverLicense.OldLicenseCode);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.DriverLicense.NewLicenceCode);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.DriverLicense.LicenseDOI.ToShortDateString());
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.DriverLicense.LicenseDOE.ToShortDateString());
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.EmergencyContact.Name);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.EmergencyContact.Surname);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.EmergencyContact.Phone);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.EmergencyContact.Email);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.EmergencyContact.PersonAddress.StreetAddress);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.EmergencyContact.PersonAddress.City);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.EmergencyContact.PersonAddress.Province);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.EmergencyContact.PersonAddress.ZipCode);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.PersonAddress.StreetAddress);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.PersonAddress.City);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.PersonAddress.Province);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.PersonAddress.ZipCode);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.PostalAddress);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.Availability);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.PayrollFactor);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewDriver.Initial);
                sqlStmnt.Append("');");

                insertedRows = dataAccess.ExecuteSQLStatement(sqlStmnt.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return insertedRows;
        }
        public int AddNewClient(Client client)
        {
            int insertedRows = -1;
            DBClass dataAccess = new DBClass();

            try
            {
                StringBuilder sqlStmnt = new StringBuilder();
                sqlStmnt.Append("INSERT INTO BTC_Clients (ClientID, CompanyName," +
                    "ContactName1, ContactSurame1, ContactPhone1, ContactEmail1," +
                    "ContactName2, ContactSurame2, ContactPhone2, ContactEmail2," +
                    "RegistrationDate, StreetAddress1, City1, Province1, ZipCode1," +
                    "StreetAddress2, City2, Province2, ZipCode2) VALUES ('");

                sqlStmnt.Append(client.ClientID);
                sqlStmnt.Append("','");
                sqlStmnt.Append(client.CompanyName);
                sqlStmnt.Append("','");
                sqlStmnt.Append(client.ContactPerson1.Name);
                sqlStmnt.Append("','");
                sqlStmnt.Append(client.ContactPerson1.Surname);
                sqlStmnt.Append("','");
                sqlStmnt.Append(client.ContactPerson1.Phone);
                sqlStmnt.Append("','");
                sqlStmnt.Append(client.ContactPerson1.Email);
                sqlStmnt.Append("','");
                sqlStmnt.Append(client.ContactPerson2.Name);
                sqlStmnt.Append("','");
                sqlStmnt.Append(client.ContactPerson2.Surname);
                sqlStmnt.Append("','");
                sqlStmnt.Append(client.ContactPerson2.Phone);
                sqlStmnt.Append("','");
                sqlStmnt.Append(client.ContactPerson2.Email);
                sqlStmnt.Append("','");
                sqlStmnt.Append(client.RegistrationDate);
                sqlStmnt.Append("','");
                sqlStmnt.Append(client.ClientAddress1.StreetAddress);
                sqlStmnt.Append("','");
                sqlStmnt.Append(client.ClientAddress1.City);
                sqlStmnt.Append("','");
                sqlStmnt.Append(client.ClientAddress1.Province);
                sqlStmnt.Append("','");
                sqlStmnt.Append(client.ClientAddress1.ZipCode);
                sqlStmnt.Append("','");
                sqlStmnt.Append(client.ClientAddress2.StreetAddress);
                sqlStmnt.Append("','");
                sqlStmnt.Append(client.ClientAddress2.City);
                sqlStmnt.Append("','");
                sqlStmnt.Append(client.ClientAddress2.Province);
                sqlStmnt.Append("','");
                sqlStmnt.Append(client.ClientAddress2.ZipCode);
                sqlStmnt.Append("');");

                insertedRows = dataAccess.ExecuteSQLStatement(sqlStmnt.ToString());


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return insertedRows;
        }

        public int UpdateClient(Client client)
        {
            int rowsUpdated = -1;

            try
            {
                DBClass dataAccess = new DBClass();
                StringBuilder sqlStmnt = new StringBuilder();

                sqlStmnt.Append("UPDATE BTC_Clients SET CompanyName = '");

                sqlStmnt.Append(client.CompanyName);
                sqlStmnt.Append("', ContactName1='");
                sqlStmnt.Append(client.ContactPerson1.Name);
                sqlStmnt.Append("',ContactSurame1='");
                sqlStmnt.Append(client.ContactPerson1.Surname);
                sqlStmnt.Append("',ContactPhone1='");
                sqlStmnt.Append(client.ContactPerson1.Phone);
                sqlStmnt.Append("',ContactEmail1='");
                sqlStmnt.Append(client.ContactPerson1.Email);
                sqlStmnt.Append("',ContactName2='");
                sqlStmnt.Append(client.ContactPerson2.Name);
                sqlStmnt.Append("',ContactSurame2='");
                sqlStmnt.Append(client.ContactPerson2.Surname);
                sqlStmnt.Append("',ContactPhone2='");
                sqlStmnt.Append(client.ContactPerson2.Phone);
                sqlStmnt.Append("',ContactEmail2='");
                sqlStmnt.Append(client.ContactPerson2.Email);
                sqlStmnt.Append("',RegistrationDate='");
                sqlStmnt.Append(client.RegistrationDate);
                sqlStmnt.Append("', StreetAddress1='");
                sqlStmnt.Append(client.ClientAddress1.StreetAddress);
                sqlStmnt.Append("', City1='");
                sqlStmnt.Append(client.ClientAddress1.City);
                sqlStmnt.Append("',Province1='");
                sqlStmnt.Append(client.ClientAddress1.Province);
                sqlStmnt.Append("',ZipCode1='");
                sqlStmnt.Append(client.ClientAddress1.ZipCode);
                sqlStmnt.Append("',StreetAddress2='");
                sqlStmnt.Append(client.ClientAddress2.StreetAddress);
                sqlStmnt.Append("',City2='");
                sqlStmnt.Append(client.ClientAddress2.City);
                sqlStmnt.Append("',Province2='");
                sqlStmnt.Append(client.ClientAddress2.Province);
                sqlStmnt.Append("',ZipCode2='");
                sqlStmnt.Append(client.ClientAddress2.ZipCode);
                //sqlStmnt.Append("', ContactFullName='");
                //sqlStmnt.Append(client.ContactFullName);
                //sqlStmnt.Append("', ContactPhone='");
                //sqlStmnt.Append(client.ContactPhone);
                //sqlStmnt.Append("', ContactEmail'");
                //sqlStmnt.Append(client.ContactEmail);
                //sqlStmnt.Append("', RegistrationDate='");
                //sqlStmnt.Append(client.RegistrationDate.ToShortDateString());
                //sqlStmnt.Append("', AddressLine1='");
                //sqlStmnt.Append(client.ClientAddress1.StreetAddress);
                //sqlStmnt.Append("', City='");
                //sqlStmnt.Append(client.ClientAddress1.City);
                //sqlStmnt.Append("', Province='");
                //sqlStmnt.Append(client.ClientAddress1.Province);
                //sqlStmnt.Append("', ZipCode='");
                //sqlStmnt.Append(client.ClientAddress1.ZipCode);
                sqlStmnt.Append("' WHERE CLientID = '" + client.ClientID + "';");

                rowsUpdated = dataAccess.ExecuteSQLStatement(sqlStmnt.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rowsUpdated;
        }

        public int DeleteClient(string clientID)
        {
            int rowsDeleted = -1;

            try
            {
                DBClass dataAccess = new DBClass();
                string sqlStmnt = "DELETE FROM BTC_Clients WHERE ClientID = '" + clientID + "';";
                rowsDeleted = dataAccess.ExecuteSQLStatement(sqlStmnt.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowsDeleted;
        }

        public int FindClient(Client client)
        {
            int numberFound = 0;

            try
            {
                DBClass dataAccess = new DBClass();
                string sqlStmnt = "SELECT * FROM BTC_Clients  WHERE ID = '" + client.ClientID + "';";
                List<Client> clients = dataAccess.ClientList(sqlStmnt);

                if (clients.Count > 0)
                {
                    numberFound = clients.Count;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return numberFound;
        }

        public int DeleteTruck(string license)
        {
            int rowsDeleted = -1;

            try
            {
                DBClass dataAccess = new DBClass();
                string sqlStmnt = "DELETE FROM BTC_Trucks WHERE LicensePlateNumber = '" + license + "';";
                rowsDeleted = dataAccess.ExecuteSQLStatement(sqlStmnt.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowsDeleted;
        }

        //public int FindTruck(string plateNumber,
        //             out string vin,
        //             out string truckType,
        //             out string transmission,
        //             out DateTime? doP,
        //             out string fuelType,
        //             out string chassisNumber,
        //             out string make,
        //             out string model,
        //             out double gvw,
        //              out double fuelTankSize,
        //               out double enginePower,
        //                out int Mileage,

        //                 out int TireSize
        //                 )
        //{
        //    int numberFound = 0;
        //    try
        //    {

        //        plateNumber = string.Empty;
        //        vin = string.Empty;
        //        truckType = string.Empty;
        //        transmission = null;
        //        doP = null;
        //        fuelType = string.Empty;
        //        chassisNumber = string.Empty;
        //        make = string.Empty;
        //        model = string.Empty;
        //        gvw = 0;
        //        fuelTankSize = 0;
        //        TireSize = 0;
        //        enginePower = 0;
        //        Mileage = 0;


        //        DBClass dataAccess = new DBClass();
        //        string sqlStmnt = "SELECT * FROM BTC_Trucks WHERE LicensePlateNumber = '" + plateNumber + "';";
        //        List<Truck> trucks = dataAccess.TruckList(sqlStmnt);

        //        if (trucks.Count > 0)
        //        {
        //            numberFound = trucks.Count;
        //            foreach (var truck in trucks)
        //            {
        //                //plateNumber =truck.LicensePlateNumber;
        //                vin = truck.VinNumber;
        //                truckType = truck.TruckType;
        //                transmission = truck.TransmissionType;
        //                fuelType = truck.FuelType;
        //                chassisNumber = truck.ChassisNumber;
        //                make = truck.Make;
        //                model = truck.Model;
        //                gvw = truck.GVW;
        //                fuelTankSize = truck.FuelTankSize;
        //                TireSize = truck.TireSize;
        //                enginePower = truck.EnginePower;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return numberFound;
        //}

        public int UpdateTruck(Truck truckUpdate)

        {
            int rowsUpdated = -1;

            try
            {
                DBClass dataAccess = new DBClass();
                StringBuilder sqlStmnt = new StringBuilder();

                sqlStmnt.Append("UPDATE BTC_Trucks SET VinNumber  = '");
                
                sqlStmnt.Append(truckUpdate.VinNumber);
                sqlStmnt.Append("', TruckType = '");
                sqlStmnt.Append(truckUpdate.TruckType);

                sqlStmnt.Append("', GVW = '");
                sqlStmnt.Append(truckUpdate.GVW);

                sqlStmnt.Append("', TransmissionType = '");
                sqlStmnt.Append(truckUpdate.TransmissionType);
                sqlStmnt.Append("', FuelType = '");
                sqlStmnt.Append(truckUpdate.FuelType);
                sqlStmnt.Append("', Mileage = '");
                sqlStmnt.Append(truckUpdate.Mileage);
                sqlStmnt.Append("', TireSize = '");
                sqlStmnt.Append(truckUpdate.TireSize);
                sqlStmnt.Append("', Steering = '");
                sqlStmnt.Append(truckUpdate.Steering);
                sqlStmnt.Append("', FuelTankSize = '");
                sqlStmnt.Append(truckUpdate.FuelTankSize);
                sqlStmnt.Append("', ChassisNumber = '");
                sqlStmnt.Append(truckUpdate.ChassisNumber);
                sqlStmnt.Append("', Make = '");
                sqlStmnt.Append(truckUpdate.Make);
                sqlStmnt.Append("', Model = '");
                sqlStmnt.Append(truckUpdate.Model);
                sqlStmnt.Append("', DateOfPurchase = '");
                sqlStmnt.Append(truckUpdate.DateOfPurchase);
                sqlStmnt.Append("', Availability = '");
                sqlStmnt.Append(truckUpdate.Availability);
                sqlStmnt.Append("' WHERE LicensePlateNumber = '");
                sqlStmnt.Append(truckUpdate.LicensePlateNumber);
                sqlStmnt.Append("';");

                rowsUpdated = dataAccess.ExecuteSQLStatement(sqlStmnt.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rowsUpdated;
        }

        public int AddNewTruck(Truck NewTruck)
        {
            int insertedRows = -1;
            DBClass dataAccess = new DBClass();
            try
            {
                StringBuilder sqlStmnt = new StringBuilder();
                sqlStmnt = new StringBuilder();
                sqlStmnt.Append("INSERT INTO BTC_Trucks (VinNumber, LicensePlateNumber, TruckType," +
                    " TransmissionType, FuelType, ChassisNumber, Make, Model, GVW, FuelTankSize," +
                    " EnginePower, Mileage, TireSize, DateOfPurchase, Steering, Availability) VALUES ('");
                sqlStmnt.Append(NewTruck.VinNumber);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewTruck.LicensePlateNumber);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewTruck.TruckType);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewTruck.TransmissionType);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewTruck.FuelType);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewTruck.ChassisNumber);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewTruck.Make);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewTruck.Model);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewTruck.GVW);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewTruck.FuelTankSize);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewTruck.EnginePower);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewTruck.Mileage);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewTruck.TireSize);
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewTruck.DateOfPurchase.ToShortDateString());
                sqlStmnt.Append("','");
                sqlStmnt.Append(NewTruck.Steering);
                sqlStmnt.Append("','");
                sqlStmnt.Append("Available");
                sqlStmnt.Append("');");
                insertedRows = dataAccess.ExecuteSQLStatement(sqlStmnt.ToString());

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return insertedRows;
        }

        public int ReportIncident(
            string truck,
            string driver,
            string location,
            string incDescrip,
            DateTime incidentDate)
        {
            int insertedRows = -1;
            DBClass dataAccess = new DBClass();
            try
            {
                StringBuilder sqlStmnt = new StringBuilder();
                sqlStmnt = new StringBuilder();
                sqlStmnt.Append("INSERT INTO BTC_Incident (Truck, Driver," +
                              " IncidentDescription, Location, IncidentDate) VALUES ('");


                sqlStmnt.Append(truck);
                sqlStmnt.Append("','");
                sqlStmnt.Append(driver);
                sqlStmnt.Append("','");
                sqlStmnt.Append(incDescrip);
                sqlStmnt.Append("','");
                sqlStmnt.Append(location);
                sqlStmnt.Append("','");
                sqlStmnt.Append(incidentDate.ToShortDateString());

                sqlStmnt.Append("');");

                insertedRows = dataAccess.ExecuteSQLStatement(sqlStmnt.ToString());

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return insertedRows;
        }

    }
}