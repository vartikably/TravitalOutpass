using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraVitaApp
{
    public class Student
    {
        [PrimaryKey]
        public Int64 MobileNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string regID { get; set; }
        public string Address { get; set; }
        public string ParentsMob { get; set; }
    }
}
