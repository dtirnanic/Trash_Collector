using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public int AddressId { get; set; }
        public int AccountId { get; set; }
        public int ApplicationUser { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
