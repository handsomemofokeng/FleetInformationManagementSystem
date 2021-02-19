using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Address
    {
        public string StreetAddress { get; set; }
        public string Province{ get; set; }

        public string City { get; set; }
        
        public int ZipCode { get; set; }

        public override string ToString()
        {
            return StreetAddress + ", " + City + ", " + Province + "," + ZipCode;
        }

    }
}
