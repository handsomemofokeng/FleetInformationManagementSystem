using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RouteInformation
    {
        public string DepartureCity { get; set; }

        public Driver RouteDriver { get; set; }

        public string DestinationCity { get; set; }

        public double Distance { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ArrivalDate { get; set; }

        public override string ToString()
        {
            return "From: " + DepartureCity + "(" + DepartureDate + ") to "
                + DestinationCity + "(" + ArrivalDate + ")";
        }        

    }
}