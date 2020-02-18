using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser ApplicationUser { get; set; }
        public int AddressId { get; set; }
        public int AccountId { get; set; }
        

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
