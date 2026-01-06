using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TourismMvc.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(200)]
        public string PasswordHash { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string Role { get; set; } = string.Empty; // Tourist / Agency

        public virtual AgencyProfile? AgencyProfile { get; set; }
        public virtual ICollection<Booking>? Bookings { get; set; }
        public virtual ICollection<Feedback>? Feedbacks { get; set; }
    }
}
