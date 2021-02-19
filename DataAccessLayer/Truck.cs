using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Truck
    {
        private string vinNumber, licensePlateNumber, transmissionType, fuelType,
            chassisNumber,make, model, availability;
        private double gVW, fuelTankSize;
        private int enginePower, mileage, tireSize;
        private DateTime dateOfPurchase;
        
        public string VinNumber
        {
            get
            {
                return vinNumber;
            }

            set
            {
                vinNumber = value;
            }
        }

        public string LicensePlateNumber
        {
            get
            {
                return licensePlateNumber;
            }

            set
            {
                licensePlateNumber = value;
            }
        }

        public string TransmissionType
        {
            get
            {
                return transmissionType;
            }

            set
            {
                transmissionType = value;
            }
        }

        public string TruckType { get; set; }

        public string FuelType
        {
            get
            {
                return fuelType;
            }

            set
            {
                fuelType = value;
            }
        }

        public string ChassisNumber
        {
            get
            {
                return chassisNumber;
            }

            set
            {
                chassisNumber = value;
            }
        }

        public string Make
        {
            get
            {
                return make;
            }

            set
            {
                make = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }

        public double GVW
        {
            get
            {
                return gVW;
            }

            set
            {
                gVW = value;
            }
        }

        public double FuelTankSize
        {
            get
            {
                return fuelTankSize;
            }

            set
            {
                if (value < 0)
                {
                    fuelTankSize = 50;
                }
                else
                {
                    fuelTankSize = value;
                }
            }
        }

        public int EnginePower
        {
            get
            {
                return enginePower;
            }

            set
            {
                if (value < 0)
                {
                    enginePower = 100;
                }
                else
                {
                    enginePower = value;
                }
            }
        }

        public int Mileage
        {
            get
            {
                return mileage;
            }

            set
            {
                if (value < 0)
                {
                    mileage = 0;
                }
                else
                {
                    mileage = value;
                }
            }
        }

        public int TireSize
        {
            get
            {
                return tireSize;
            }

            set
            {
                tireSize = value;
            }
        }

        public DateTime DateOfPurchase
        {
            get
            {
                return dateOfPurchase;
            }

            set
            {
                if (value > DateTime.Now)
                {
                    dateOfPurchase = DateTime.Now;
                }
                else
                {
                    dateOfPurchase = value;
                }
            }
        }

        public string Steering { get; set; }

        public string Availability
        {
            get
            {
                return availability;
            }

            set
            {
                availability = value;
            }
        }

        public override string ToString()
        {
            return Make + " " + Model + " (" + LicensePlateNumber + "): " + Availability;
        }
    }
}