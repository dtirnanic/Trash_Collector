using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }

    }
}
