using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Payroll
    {

        private Driver driver;
        //private DateTime travelStartDate, travelEndDate;
        //private string departurePoint, destinationPont;
        private int distance;
        private double totalPay;

        public Payroll( Driver driver, int distance)
        {
            this.driver = driver;
            this.distance = distance;
        }

        public Driver Driver
        {
            get; set;
        }

        public RouteInformation Route { get; set; }

        public DateTime TravelStartDate
        {
            get; set;
        }

        public DateTime TravelEndDate
        {
            get; set;
        }

        public string DriverName
        {
            get; set;
        }

        public string DeparturePoint
        {
            get; set;
        }

        public string DestinationPont
        {
            get; set;
        }

        public int Distance
        {
            get; set;
        }

        public double TotalPay
        {
            get { return totalPay; }
            set { totalPay = driver.PayrollFactor * distance; }
        }

    }
}