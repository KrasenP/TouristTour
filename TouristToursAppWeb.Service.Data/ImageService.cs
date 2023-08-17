using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristToursAppWeb.Data;
using TouristToursAppWeb.Data.Models;
using TouristToursAppWeb.Service.Data.Interfaces;
using TouristToursAppWeb.Web.ViewModel;

namespace TouristToursAppWeb.Service.Data
{
    public class ImageService : IImageService
    {
        private readonly TouristToursAppWebDbContext _dbContext;
        public ImageService(TouristToursAppWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateImage(Guid tourId, string fileName, string extensions)
        {
            TourImages tourImages = new TourImages()
            {
                FileName = fileName,
                Extensions = extensions,
                TourId = tourId
            };

            await _dbContext.ToursImages.AddAsync(tourImages);
            await _dbContext.SaveChangesAsync();
        }
    }
}
