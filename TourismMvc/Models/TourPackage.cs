using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourismMvc.Models
{
    public class TourPackage
    {
        public int TourPackageId { get; set; }

        [Required]
        [ForeignKey("AgencyProfile")]
        public int AgencyId { get; set; }

        [Required, StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required, StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Destination { get; set; } = string.Empty;

        [Range(1, 365)]
        public int DurationDays { get; set; }

        [Range(0, 999999)]
        public decimal BasePrice { get; set; }

        [Range(1, 200)]
        public int GroupSizeLimit { get; set; }

        [StringLength(300)]
        public string ImageUrl { get; set; } = string.Empty;

        public virtual AgencyProfile? AgencyProfile { get; set; }
        public virtual ICollection<TourSchedule>? TourSchedules { get; set; }
    }
}
