using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourismMvc.Models;

namespace TourismMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly TourismContext _context;

        public HomeController(TourismContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // 👉 TODO: Replace with your real group members
            var groupMembers = new List<GroupMember>
            {
                new GroupMember { StudentId = "S123456", FullName = "Student One" },
                new GroupMember { StudentId = "S234567", FullName = "Student Two" },
                new GroupMember { StudentId = "S345678", FullName = "Student Three" },
                new GroupMember { StudentId = "S456789", FullName = "Student Four" }
            };

            var featuredTours = _context.TourPackages
                .Include(t => t.AgencyProfile)
                .Take(6)
                .ToList();

            var model = new HomeIndexViewModel
            {
                GroupMembers = groupMembers,
                FeaturedTours = featuredTours
            };

            return View(model);
        }
    }
}
