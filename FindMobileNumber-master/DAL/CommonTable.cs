using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CommonTable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string TelephoneNumber { get; set; }
        public string Owner { get; set; }
        public System.DateTime lastStatusChange { get; set; }
    }
}
