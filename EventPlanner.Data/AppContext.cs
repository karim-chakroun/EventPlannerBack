using EventPlanner.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Data
{
    public class AppContext : IdentityDbContext
    {
        public AppContext()
        {
            //Database.EnsureCreated();
        }

        public DbSet<Exemple> Exemples { get; set; }

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
