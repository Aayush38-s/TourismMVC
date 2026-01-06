using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourismMvc.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        [ForeignKey("TourSchedule")]
        public int TourScheduleId { get; set; }

        [Required]
        [ForeignKey("Tourist")]
        public int TouristId { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime BookingDate { get; set; }

        [Range(1, 200)]
        public int NumberOfPeople { get; set; }

        [Required, StringLength(20)]
        public string Status { get; set; } = "Pending";

        [Required, StringLength(20)]
        public string PaymentStatus { get; set; } = "Pending";

        public virtual TourSchedule? TourSchedule { get; set; }
        public virtual User? Tourist { get; set; }
        public virtual Feedback? Feedback { get; set; }
    }
}
