using Microsoft.EntityFrameworkCore;
using TouristToursAppWeb.Data;
using TouristToursAppWeb.Data.Models;
using TouristToursAppWeb.Service.Data.Interfaces;
using TouristToursAppWeb.Web.ViewModel;


namespace TouristToursAppWeb.Service.Data
{
    public class LocationService : ILocationService
    {
        private readonly TouristToursAppWebDbContext _touristToursAppWebDbContext;
        public LocationService(TouristToursAppWebDbContext touristToursAppWebDbContext)
        {
            _touristToursAppWebDbContext=touristToursAppWebDbContext;
        }
        public async Task<LocationViewModel?> LocationManager(string country, string city)
        {
            LocationViewModel? getExistLocation = await _touristToursAppWebDbContext.Locations.Where(l => l.Country == country && l.City == city)
                .Select(x => new LocationViewModel() 
                {
                    Id = x.Id,
                    Country = x.Country,
                    City = x.City
                })
                .FirstOrDefaultAsync();

            if (getExistLocation==null)
            {
                Location newLocation = new Location()
                {
                    Country = country,
                    City = city
                };

               await _touristToursAppWebDbContext.Locations.AddAsync(newLocation);
                await _touristToursAppWebDbContext.SaveChangesAsync();

                return await _touristToursAppWebDbContext.Locations.Where(x => x == newLocation)
                    .Select(l => new LocationViewModel()
                    {
                        Id = newLocation.Id,
                        Country = newLocation.Country,
                        City = newLocation.City
                    })
                    .FirstOrDefaultAsync();
            }

            return getExistLocation;

        }

    }
}
