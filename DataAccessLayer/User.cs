using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class User
    {
        public string UserEmail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        //public  ProfilePicture { get; set; }

        public override string ToString()
        {
            return Name + " " + Surname + " (" + Role + ")";
        }
    }
}