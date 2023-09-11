using Microsoft.AspNetCore.Mvc;
using TouristToursAppWeb.Service.Data;
using TouristToursAppWeb.Service.Data.Interfaces;
using TouristToursAppWeb.Web.ViewModel;
using static TouristToursAppWeb.Web.Infrastructure.ClaimPrincipalExtensions;
using static TouristToursAppWeb.Common.NotificationMessage;

namespace TouristToursAppWeb.Controllers
{
    public class TourBookingController : BaseController
    {
        private readonly ITourBookingService _tourBookingService; 
        private readonly IUserGuideService _userGuideService;

        public TourBookingController(ITourBookingService tourBookingService,IUserGuideService userGuideService)
        {
            _tourBookingService = tourBookingService;
            _userGuideService = userGuideService;   
        }
   
        public IActionResult MakeBooking(string tourId)
        {
            var model = new TourBokingFormViewModel()
            {
                TourId = Guid.Parse(tourId)
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> MakeBooking(TourBokingFormViewModel viewModel) 
        {
            if (ModelState.IsValid==false)
            {
                return View(viewModel);
            }

            var currentUser = this.User.GetCurrentUserId();
            await _tourBookingService.MakeBooking(viewModel,currentUser);
          

            return RedirectToAction("Index", "Home");


        }


        public async Task<IActionResult> BookingOnTour(string tourId) 
        {
            var model  = await _tourBookingService.GetBookedTours(tourId);

            return View(model);

        }

        public async Task<IActionResult> UpdateBookingStatus(string bookedId) 
        {
            string booked = bookedId;

            return RedirectToAction("Index", "Home");
        }


    }
}
