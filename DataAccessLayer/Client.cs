    using System;

namespace DataAccessLayer
{
    public class Client
    {
        //private string clientID;
        //private string companyName, contactFullName;
        //private string contactEmail, contactPhone;
        //private DateTime registrationDate;
        //private Address clientAddress;

        public Client()
        {

        }

        //public Client(string companyName, string contactFullName, string contactEmail, string contactPhone,
        //    Address clientAdddress, DateTime registrationDate)
        //{
        //    if (clientID == string.Empty)
        //    {
        //        clientID = GetNewClientID();
        //    }
        //    CompanyName = companyName;
        //    ContactFullName = contactFullName;
        //    ContactEmail = contactEmail;
        //    ContactPhone = contactPhone;
        //    ClientAddress = clientAdddress;
        //    RegistrationDate = registrationDate;
        //}

        public string ClientID {
            get; set;
        }

        public string CompanyName
        {
            get; set;
        }

        public Person ContactPerson1 { get; set; }

        public Person ContactPerson2 { get; set; }
        
        public DateTime RegistrationDate
        {
            get; set;
        }

        public Address ClientAddress1
        {
            get; set;
        }

        public Address ClientAddress2
        {
            get; set;
        }

        public override string ToString()
        {
            return ClientID + ": " + CompanyName + "(" + ContactPerson1.ToString() + ") " 
                + ClientAddress1.ToString();

        }

    }
}