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

        public  async void ChangeStatus(string bookId)
        {
           var getTourBook = await _dbContext.TourBookings.Where(x=>x.Id.ToString()==bookId).FirstOrDefaultAsync();

            if (getTourBook.Actions==false)
            {
                getTourBook.Actions = true;
            }
            else
            {
                getTourBook.Actions = false;
            }

            await _dbContext.SaveChangesAsync();

        }

        public async Task<List<TourBookedViewModel>> GetBookedTours(string tourId)
        {
            string id = tourId;
           var model = await _dbContext.TourBookings.Where(t => t.TourId.ToString() == tourId)
                .Select(x => new TourBookedViewModel()
                {
                    Id = x.Id,
                    TourName = x.Tour.Title,
                    BookingUserName = x.AppUser.UserName,
                    BookingUserPhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    CountOfPeople = x.CountOfPeople,
                    Actions =x.Actions,
                    BookedDate = x.BookedDate

                }).ToListAsync();

            return model;
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
                CountOfPeople = bokingFormViewModel.CountOfPeople
               
                
            };

            await _dbContext.TourBookings.AddAsync(tourBooking);
            await _dbContext.SaveChangesAsync();


        }
        
    }
}
