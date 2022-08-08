using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
 
           modelBuilder.Entity<Manager>()
               .HasData(
                   new Manager { ManagerId = 1, FirstName = "Jan", LastName = "Kowalski", Bands = new List<Band>() },
                   new Manager { ManagerId = 2, FirstName = "Piotr", LastName = "Nowak", Bands = new List<Band>() },
                   new Manager { ManagerId = 3, FirstName = "Adam", LastName = "Wiśniewski", Bands = new List<Band>() });
                   
           
            modelBuilder.Entity<Band>()
                .HasData(
                    new Band { BandId = 1, Name = "Band1", ManagerId = 1 },
                    new Band { BandId = 2, Name = "Band2", ManagerId = 1 },
                    new Band { BandId = 3, Name = "Band3", ManagerId = 2});

        }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<ConcertTour> ConcertTours { get; set; }
        public DbSet<Manager> Managers { get; set; }
    }
}
