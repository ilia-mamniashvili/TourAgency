using DTO;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Tests;
public class Seeder
{
    private TourAgencyDbContext _context;

    public Seeder(TourAgencyDbContext context)
    {
        _context = context;
    }

    public void ClearDatabase()
    {
        _context.Database.ExecuteSqlRaw("DELETE FROM Cities");
        _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Cities', RESEED, 0)");

        _context.Database.ExecuteSqlRaw("DELETE FROM Countries");
        _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Countries', RESEED, 0)");

        _context.Database.ExecuteSqlRaw("DELETE FROM Hotels");
        _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Hotels', RESEED, 0)");

        _context.Database.ExecuteSqlRaw("DELETE FROM Services");
        _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Services', RESEED, 0)");
    }
    public void SeedBuilder()
    {
        CountrySeedBuilder();
        CitySeedBuilder();
        ServiceSeedBuilder();
        HotelSeedBuilder();
    }

    private void CountrySeedBuilder()
    {
        foreach (var country in CountryBuilder())
        {
            _context.Countries!.Add(country);
        }

        _context.SaveChanges();
    }

    private void CitySeedBuilder()
    {
        var cities = CityBuilder();
        //Assigning Countries
        cities[0].Country = _context.Countries!.FirstOrDefault(c => c.Id == 1)!;
        cities[1].Country = _context.Countries!.FirstOrDefault(c => c.Id == 1)!;
        cities[2].Country = _context.Countries!.FirstOrDefault(c => c.Id == 2)!;
        cities[3].Country = _context.Countries!.FirstOrDefault(c => c.Id == 3)!;
        cities[4].Country = _context.Countries!.FirstOrDefault(c => c.Id == 4)!;

        foreach (var city in cities)
        {
            _context.Cities!.Add(city);
        }
    }

    private void ServiceSeedBuilder()
    {
        foreach (var service in ServiceBuilder())
        {
            _context.Services!.Add(service);
        }

        _context.SaveChanges();
    }
    private void HotelSeedBuilder()
    {
        var hotels = HotelBuilder();
        //Assigning Cities
        hotels[0].City = _context.Cities!.FirstOrDefault(c => c.Id == 1)!;
        hotels[1].City = _context.Cities!.FirstOrDefault(c => c.Id == 2)!;
        hotels[2].City = _context.Cities!.FirstOrDefault(c => c.Id == 3)!;
        hotels[3].City = _context.Cities!.FirstOrDefault(c => c.Id == 4)!;
        hotels[4].City = _context.Cities!.FirstOrDefault(c => c.Id == 5)!;

        //Assigning Services
        hotels[0].AdditionalServices = _context.Services!.Where(s => s.Id == 1 || s.Id == 2).ToList();
        hotels[1].AdditionalServices = _context.Services!.Where(s => s.Id == 1).ToList();
        hotels[2].AdditionalServices = _context.Services!.Where(s => s.Id == 2).ToList();
        hotels[3].AdditionalServices = _context.Services!.Where(s => s.Id == 1 || s.Id == 2).ToList();

        foreach (var hotel in hotels)
        {
            _context.Hotels!.Add(hotel);
        }

        _context.SaveChanges();
    }

    private List<City> CityBuilder()
    {
        return new List<City>
    {
        new City { Name = "Test City 1", Status = new EntityStatus(), IsoCode = "IO1" },
        new City { Name = "Test City 2", Status = new EntityStatus(), IsoCode = "IO2" },
        new City { Name = "Test City 3", Status = new EntityStatus(), IsoCode = "IO3" },
        new City { Name = "Test City 4", Status = new EntityStatus(), IsoCode = "IO4" },
        new City { Name = "Test City 5", Status = new EntityStatus(), IsoCode = "IO5" }
    };
    }

    private List<Country> CountryBuilder()
    {
        return new List<Country>
    {
        new Country { Name = "Country", IsoCode = "Is1", Status = new EntityStatus() },
        new Country { Name = "Country 2", IsoCode = "Is2", Status = new EntityStatus() },
        new Country { Name = "Country 3", IsoCode = "Is3", Status = new EntityStatus() },
        new Country { Name = "Country 4", IsoCode = "Is4", Status = new EntityStatus() },
        new Country { Name = "Country 5", IsoCode = "Is5", Status = new EntityStatus() }
    };
    }

    private List<Hotel> HotelBuilder()
    {
        return new List<Hotel>
    {
        new Hotel { Name = "Hotel", DailyPrice = 54, Status = new EntityStatus(), IncludesMeal = true, Star = StarRating.Five},
        new Hotel { Name = "Hotel 2", DailyPrice = 100, Status = new EntityStatus(), IncludesMeal = false, Star = StarRating.Four },
        new Hotel { Name = "Hotel 3", DailyPrice = 150, Status = new EntityStatus(), IncludesMeal = true, Star = StarRating.Three },
        new Hotel { Name = "Hotel 4", DailyPrice = 200, Status = new EntityStatus(), IncludesMeal = false, Star = StarRating.Two },
        new Hotel { Name = "Hotel 5", DailyPrice = 250, Status = new EntityStatus(), IncludesMeal = true, Star = StarRating.One }
    };
    }

    private List<Service> ServiceBuilder()
    {
        return new List<Service>
    {
        new Service { Name = "Wi-Fi", Status = new EntityStatus(), },
        new Service { Name = "Television", Status = new EntityStatus(), },
    };
    }
}
