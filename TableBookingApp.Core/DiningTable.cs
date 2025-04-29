using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableBookingApp.Core
{
    public partial class DiningTable
    {
        public int Id { get; set; }

        public int RestaurantBranchid { get; set; }

        [MaxLength(100)]
        public string? Tablename { get; set; }

        [Required]
        public int Capacity { get; set; }

        public virtual RestaurantBranch Branch { get; set; } = null!;

        public virtual ICollection<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();
    }
}
