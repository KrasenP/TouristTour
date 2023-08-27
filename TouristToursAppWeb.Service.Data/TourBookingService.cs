using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
   
    public class TourBookingService : ITourBookingService
    {
        private readonly TouristToursAppWebDbContext _dbContext;


        public TourBookingService(TouristToursAppWebDbContext touristToursAppWebDbContext)
        {
            _dbContext = touristToursAppWebDbContext;
        }

  

        public async Task MakeBooking(TourBokingFormViewModel bokingFormViewModel,string currentUserId)
        {

            TourBooking tourBooking = new TourBooking()
            {
                PhoneNumber = bokingFormViewModel.PhoneNumber,
                AppUserId = Guid.Parse(currentUserId),
                Email = bokingFormViewModel.Email,
                BookedDate = bokingFormViewModel.BookedDate,
                TourId = bokingFormViewModel.TourId,
                IsBooked = false,
                IsRefused = false
                
            };

            await _dbContext.TourBookings.AddAsync(tourBooking);
            await _dbContext.SaveChangesAsync();


        }
    }
}
