using DTO;
using Microsoft.EntityFrameworkCore;

namespace Repositories;
public class TourAgencyDbContext : DbContext
{
    public DbSet<City>? Cities { get; set; }

    public DbSet<Country>? Countries { get; set; }

    public DbSet<Hotel>? Hotels { get; set; }

    public DbSet<Service>? Services { get; set; }

    public DbSet<Tour>? Tours { get; set; }

    public DbSet<TourBooking>? TourBookings { get; set; }

    public DbSet<Tourist>? Tourists { get; set; }

    public DbSet<TourItem>? TourItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=.;Database=TourAgencyDb;Integrated Security = true;TrustServerCertificate=true");
    }
}
