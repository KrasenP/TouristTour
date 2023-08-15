using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TouristToursAppWeb.Data.Models;

namespace TouristToursAppWeb.Data
{
    public class TouristToursAppWebDbContext: IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>
    {
        public TouristToursAppWebDbContext(DbContextOptions<TouristToursAppWebDbContext> options):base(options)
        {

        }
        public DbSet<Tour> Tours { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<TourBooking> TourBookings { get; set; }

        public DbSet<DateSet> Dates { get; set; }

        public DbSet<UserGuide> UserGuides { get; set; }

        public DbSet<TourImages> ToursImages { get; set; }

        public DbSet<ToursDatesSet> ToursDates { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           

            Assembly assembliWithConfig = Assembly.GetAssembly(typeof(TouristToursAppWebDbContext)) ?? Assembly.GetExecutingAssembly();


            builder.ApplyConfigurationsFromAssembly(assembliWithConfig);



            base.OnModelCreating(builder);
        }

    }
}
