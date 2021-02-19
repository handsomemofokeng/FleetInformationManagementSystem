using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Person
    {

        //private string personID, personName, personSurname, personPhone, personEmail;

        //private Address personAddress;     

        //public Person(string personID, string personName, string personSurname,
        //    string personPhone, string personEmail)
        //{
        //    PersonID = personID;
        //    PersonName = personName;
        //    PersonSurname = personSurname;
        //    PersonPhone = personPhone;
        //    PersonEmail = personEmail;
        //}


        public string Email
        {
            get; set;
        }

        public string ID
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Phone
        {
            get; set;
        }

        public string Surname
        {
            get; set;
        }

        public string Relationship { get; set; }

        public string PostalAddress { get; set; }

        public Address PersonAddress
        {
            get; set;
        }

        public override string ToString()
        {
            return Name + " " + Surname + "(" + Email + "/" + Phone + ")";
        }

    }
}
