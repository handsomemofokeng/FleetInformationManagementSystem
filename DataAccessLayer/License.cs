using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class License
    {
        string  newLicenceCode;
        int oldLicenseCode;
        DateTime licenseDOI,licenceDOE;

        public License( int oldLicenseCode, string newLicenceCode, DateTime licenseDOI, DateTime licenseDOE)
        {
            OldLicenseCode = oldLicenseCode;
            NewLicenceCode = newLicenceCode;
            LicenseDOI = licenseDOI;
            LicenseDOE = licenseDOE;
        }      

        public DateTime LicenseDOI
        {
            get
            {
                return licenseDOI;
            }

            set
            {
                licenseDOI = value;
            }
        }

        public DateTime LicenseDOE
        {
            get
            {
                return licenceDOE;
            }

            set
            {
                licenceDOE = value;
            }
        }

        public int OldLicenseCode
        {
            get
            {
                return oldLicenseCode;
            }

            set
            {
                if (value > 14 || value < 1)
                {
                    oldLicenseCode = 1;
                }
                else
                {
                    oldLicenseCode = value;
                }
            }
        }

        public string NewLicenceCode
        {
            get
            {
                return newLicenceCode;
            }

            set
            {
                newLicenceCode = value;
            }
        }

        public override string ToString()
        {
            return NewLicenceCode + ": " + OldLicenseCode + "(Expires on: " + LicenseDOE + ")";
        } 

    }
}
