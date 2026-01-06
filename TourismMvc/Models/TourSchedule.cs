using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourismMvc.Models
{
    public class TourSchedule
    {
        public int TourScheduleId { get; set; }

        [Required]
        [ForeignKey("TourPackage")]
        public int TourPackageId { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime TourDate { get; set; }

        [Range(0, 200)]
        public int AvailableSeats { get; set; }

        public virtual TourPackage? TourPackage { get; set; }
        public virtual ICollection<Booking>? Bookings { get; set; }
    }
}
