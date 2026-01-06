using Microsoft.EntityFrameworkCore;

namespace TourismMvc.Models
{
    public class TourismContext : DbContext
    {
        public TourismContext(DbContextOptions<TourismContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<AgencyProfile> AgencyProfiles => Set<AgencyProfile>();
        public DbSet<TourPackage> TourPackages => Set<TourPackage>();
        public DbSet<TourSchedule> TourSchedules => Set<TourSchedule>();
        public DbSet<Booking> Bookings => Set<Booking>();
        public DbSet<Feedback> Feedbacks => Set<Feedback>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Money precision
            modelBuilder.Entity<TourPackage>()
                .Property(t => t.BasePrice)
                .HasPrecision(18, 2);

            // User ↔ AgencyProfile (1–1, cascade OK)
            modelBuilder.Entity<AgencyProfile>()
                .HasOne(a => a.User)
                .WithOne(u => u.AgencyProfile!)
                .HasForeignKey<AgencyProfile>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User ↔ Booking (Tourist)  → NO CASCADE
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Tourist)
                .WithMany(u => u.Bookings!)
                .HasForeignKey(b => b.TouristId)
                .OnDelete(DeleteBehavior.Restrict);

            // TourSchedule ↔ Booking → cascade OK
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.TourSchedule)
                .WithMany(ts => ts.Bookings!)
                .HasForeignKey(b => b.TourScheduleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Booking ↔ Feedback (1–1) → cascade OK
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Booking)
                .WithOne(b => b.Feedback!)
                .HasForeignKey<Feedback>(f => f.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            // User ↔ Feedback (Tourist) → NO CASCADE
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Tourist)
                .WithMany(u => u.Feedbacks!)
                .HasForeignKey(f => f.TouristId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
