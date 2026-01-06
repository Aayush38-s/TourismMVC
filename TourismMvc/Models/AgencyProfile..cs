using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourismMvc.Models
{
    public class AgencyProfile
    {
        [Key]
        public int AgencyId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required, StringLength(150)]
        public string AgencyName { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [StringLength(200)]
        public string ContactInfo { get; set; } = string.Empty;

        [StringLength(300)]
        public string ImageUrl { get; set; } = string.Empty;

        public virtual User? User { get; set; }
        public virtual ICollection<TourPackage>? TourPackages { get; set; }
    }
}
