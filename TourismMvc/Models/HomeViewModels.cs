using System.Collections.Generic;

namespace TourismMvc.Models
{
    public class GroupMember
    {
        public string StudentId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }

    public class HomeIndexViewModel
    {
        public List<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();
        public List<TourPackage> FeaturedTours { get; set; } = new List<TourPackage>();
    }
}
