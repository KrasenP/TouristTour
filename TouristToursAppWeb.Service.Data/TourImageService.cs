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
        private readonly TouristToursAppWebDbContext _dbConntext;
        public TourImageService(TouristToursAppWebDbContext touristToursAppWebDbContext)
        {
            _dbConntext = touristToursAppWebDbContext;
        }
        public async Task DelatePicture(string tourId,int imageId)
        {

           
            throw new NotImplementedException();
        }
    }
}
