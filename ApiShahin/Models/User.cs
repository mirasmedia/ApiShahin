using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiShahin.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phonenumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
    }
}
