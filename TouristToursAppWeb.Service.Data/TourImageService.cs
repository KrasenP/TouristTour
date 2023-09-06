using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristToursAppWeb.Data;
using TouristToursAppWeb.Service.Data.Interfaces;

namespace TouristToursAppWeb.Service.Data
{
    public class TourImageService : ITourImageService
    {
        private readonly TouristToursAppWebDbContext _dbContext;
        public TourImageService(TouristToursAppWebDbContext touristToursAppWebDbContext)
        {
            _dbContext = touristToursAppWebDbContext;
        }
        public async Task DelatePicture(string imageFileName)
        {

            var imageForDelete = await _dbContext.ToursImages.Where(x => x.FileName == imageFileName).FirstOrDefaultAsync();

            _dbContext.ToursImages.Remove(imageForDelete);
            await _dbContext.SaveChangesAsync();

        }
    }
}
