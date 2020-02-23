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
        public DayOfWeek PickUpDay { get; set; } = DayOfWeek.Monday;
        public DateTime OneTimePickup { get; set; } = DateTime.Now;
        public DateTime StartDay { get; set; } = DateTime.Now;
        public DateTime EndDay { get; set; } = DateTime.Now;
        public bool IsSuspended { get; set; } = false;
        public double Balance { get; set; } = 0;

    }
}
