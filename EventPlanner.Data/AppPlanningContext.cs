using EventPlanner.Domain;
using EventPlanner.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Data
{
    public class AppPlanningContext : IdentityDbContext
    {
        public AppPlanningContext()
        {
            //Database.EnsureCreated();
        }

        public AppPlanningContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ExternServices> ExternServices { get; set; }
        public DbSet<Exemple> Exemples { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Feedback> Feedback { get; set; }

        //public DbSet<Exemple> Exemples { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=EventPlanner-DB;
            Integrated Security=true;
            MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
