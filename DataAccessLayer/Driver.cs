using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Driver : Person
    {

        //private string nickname, residentialAddress, postalAddress, phone, email, newLicenseCode,
        //    pointOfDeparture, destination;
        //private int oldLicenseCode, distanceTravelled;
        //private DateTime licenseDOI, licenseDOE, travelStartDate, travelEndDate;
        //double totalPay, fuelCost;

        //public Driver(string driverID, string driverName, string driverSurname, string driverPhone, string driverEmail,
        //    License driverLicense, Person emergencyContact, Address residentialAddress, Address postalAddress, double PayrollFactor)
        //    : base(driverID, driverName, driverSurname, driverPhone, driverEmail)
        //{
        //    DriverLicense = driverLicense;
        //    EmergencyContact = emergencyContact;
        //    ResidentialAddress = residentialAddress;
        //    PostalAddress = PostalAddress;
        //    PayrollFactor = getPayrollFactor();
        //}

        public License DriverLicense { get; set; }

        public Person EmergencyContact { get; set; }

        public string Nickname
        {
            get; set;
        }

        public char Initial { get; set; }

       
        public string Availability { get; set; }

        public double PayrollFactor
        {
            get; set;
        }

        //public string Phone
        //{
        //    get; set;
        //}

        //public string Email
        //{
        //    get; set;
        //}

        //public string PointOfDeparture
        //{
        //    get; set;
        //}

        //public string Destination
        //{
        //    get; set;
        //}

        //public double TotalPay
        //{
        //    get; set;
        //}

        //public double FuelCost
        //{
        //    get; set;
        //}

       

        public override string ToString()
        {
            return base.ToString() + " (" + Availability + ")";
        }

    }
}