using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string PickUpDay { get; set; }
        public DateTime OneTimePickup { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public bool IsSuspended { get; set; }
        public double Balance { get; set; }

    }
}
