using Microsoft.EntityFrameworkCore;
using SurfingBlogRt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurfingBlogRt.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public IEnumerable<User> Comnpanies { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<Application> Applications { get; set; }

        public DbSet<AnnoucementType> AnnoucementTypes { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DataContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            Comnpanies = Users
                .Include(u => u.Role)
                .Where(u => u.Role.RoleName.Equals("Company"));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=internshipsBlog;Username=postgres;Password=postgres");
        }
    }
}
